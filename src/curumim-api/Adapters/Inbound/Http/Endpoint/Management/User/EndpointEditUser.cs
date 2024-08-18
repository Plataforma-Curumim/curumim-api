using curumim_api.Adapters.Inbound.Http.Mappers.Shared;
using curumim_api.Adapters.Inbound.Http.Models.Filter;
using curumim_api.Adapters.Inbound.Http.Models.Management.User.EditUser;
using curumim_api.Adapters.Inbound.Http.Models.Management.User.RegisterUser;
using curumim_api.Application.Core.DomainModels.Base;
using curumim_api.Application.Core.Enums;
using curumim_api.Application.Ports.Inbound.UseCases.Management.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace curumim_api.Adapters.Inbound.Http.Endpoint.Management.User
{
    public static class EndpointEditUser
    {
        public static void AddEndpointEditUser(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapPatch("/edit/user", EditUser)
                        .AddEndpointFilter<ValidationFilter<RequestEditUser>>()
                        .Produces<ResponseEditUser>(201)
                        .Produces<BaseError>(422)
                        .Produces<BaseError>(500);
            //.RequireAuthorization();

        }

        public static async Task<Results<Created<ResponseEditUser>, BadRequest<BaseError>>>
            EditUser([FromServices] IUseCaseEditUser useCase,
                                [FromQuery] string idempotenceKey,
                                [FromBody] RequestEditUser request)
        {
            var mapper = MapperShared<RequestEditUser>.MapToDomain(request, idempotenceKey);
            var responseUseCase = useCase.Edit(mapper);

            if (responseUseCase.Status != EnumState.SUCCESS) return TypedResults.BadRequest(responseUseCase.ErrorObject!);

            var response = JsonSerializer.Deserialize<ResponseEditUser>(responseUseCase!.SucessObject!.msgOUT!);
            return TypedResults.Created("", response);
        }
    }
}
