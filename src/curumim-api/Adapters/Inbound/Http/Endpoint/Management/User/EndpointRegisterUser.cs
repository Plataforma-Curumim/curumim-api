using curumim_api.Adapters.Inbound.Http.Mappers.Shared;
using curumim_api.Adapters.Inbound.Http.Models.Filter;
using curumim_api.Adapters.Inbound.Http.Models.Management.User.RegisterUser;
using curumim_api.Application.Core.DomainModels.Base;
using curumim_api.Application.Core.Enums;
using curumim_api.Application.Ports.Inbound.UseCases.Management.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace curumim_api.Adapters.Inbound.Http.Endpoint.Management.User
{
    public static class EndpointRegisterUser
    {
        public static void AddEndpointRegisterUser(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapPost("/register/user", RegisterUser)
                        .AddEndpointFilter<ValidationFilter<RequestRegisterUser>>()
                        .Produces<ResponseRegisterUser>(201)
                        .Produces<BaseError>(422)
                        .Produces<BaseError>(500);
            //.RequireAuthorization();

        }

        public static async Task<Results<Created<ResponseRegisterUser>, BadRequest<BaseError>>>
            RegisterUser([FromServices] IUseCaseRegisterUser useCase,
                                [FromQuery] string idempotenceKey,
                                [FromBody] RequestRegisterUser request)
        {
            var mapper = MapperShared<RequestRegisterUser>.MapToDomain(request, idempotenceKey);
            var responseUseCase = useCase.Register(mapper);

            if (responseUseCase.Status != EnumState.SUCCESS) return TypedResults.BadRequest(responseUseCase.ErrorObject!);

            var response = JsonSerializer.Deserialize<ResponseRegisterUser>(responseUseCase!.SucessObject!.msgOUT!);
            return TypedResults.Created("", response);
        }
    }
}
