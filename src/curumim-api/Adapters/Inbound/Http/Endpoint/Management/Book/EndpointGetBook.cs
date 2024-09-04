using curumim_api.Adapters.Inbound.Http.Mappers.Shared;
using curumim_api.Adapters.Inbound.Http.Models.Filter;
using curumim_api.Adapters.Inbound.Http.Models.Management.Book.EditBook;
using curumim_api.Adapters.Inbound.Http.Models.Management.Book.GetBook;
using curumim_api.Application.Core.DomainModels.Base;
using curumim_api.Application.Core.Enums;
using curumim_api.Application.Ports.Inbound.UseCases.Management.Book;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace curumim_api.Adapters.Inbound.Http.Endpoint.Management.Book
{
    public static class EndpointGetBook
    {
        public static void AddEndpointGetBook(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapGet("/get/book", GetBook)
                        .Produces<ResponseGetBook>(200)
                        .Produces<BaseError>(422)
                        .Produces<BaseError>(500);
            //.RequireAuthorization();

        }

        public static async Task<Results<Ok<ResponseGetBook>, BadRequest<BaseError>>>
            GetBook([FromServices] IUseCaseGetBook useCase,
                                [FromQuery] string rfidId)
        {
            var request = new RequestGetBook(rfidId);
            var mapper = MapperShared<RequestGetBook>.MapToDomain(request, "");
            var responseUseCase = useCase.Get(mapper);

            if (responseUseCase.Status != EnumState.SUCCESS) return TypedResults.BadRequest(responseUseCase.ErrorObject!);

            var response = JsonSerializer.Deserialize<ResponseGetBook>(responseUseCase!.SucessObject!.msgOUT!);
            return TypedResults.Ok(response);
        }
    }
}
