using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using curumim_api.Application.Core.Enums;
using curumim_api.Adapters.Inbound.Http.Mappers.Shared;
using curumim_api.Application.Core.DomainModels.Base;
using curumim_api.Adapters.Inbound.Http.Models.Filter;
using curumim_api.Adapters.Inbound.Http.Models.Management.Book.RegisterBook;
using curumim_api.Application.Ports.Inbound.UseCases.Management.Book;

namespace curumim_api.Adapters.Inbound.Http.Endpoint.Management.Book
{
    public static class EndpointRegisterBook
    {
        public static void AddEndpointRegisterBook(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapPost("/register/book", RegisterBook)
                        .AddEndpointFilter<ValidationFilter<RequestRegisterBook>>()
                        .Produces<ResponseRegisterBook>(201)
                        .Produces<BaseError>(422)
                        .Produces<BaseError>(500);
            //.RequireAuthorization();

        }

        public static async Task<Results<Created<ResponseRegisterBook>, BadRequest<BaseError>>>
            RegisterBook([FromServices] IUseCaseRegisterBook useCase,
                                [FromQuery] string idempotenceKey,
                                [FromBody] RequestRegisterBook request)
        {
            var mapper = MapperShared<RequestRegisterBook>.MapToDomain(request, idempotenceKey);
            var responseUseCase = useCase.Register(mapper);

            if (responseUseCase.Status != EnumState.SUCCESS) return TypedResults.BadRequest(responseUseCase.ErrorObject!);

            var response = JsonSerializer.Deserialize<ResponseRegisterBook>(responseUseCase!.SucessObject!.msgOUT!);
            return TypedResults.Created("", response);
        }
    }
}
