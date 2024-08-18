using curumim_api.Adapters.Inbound.Http.Mappers.Shared;
using curumim_api.Adapters.Inbound.Http.Models.Filter;
using curumim_api.Adapters.Inbound.Http.Models.Management.Book.EditBook;
using curumim_api.Adapters.Inbound.Http.Models.Management.Book.RegisterBook;
using curumim_api.Application.Core.DomainModels.Base;
using curumim_api.Application.Core.Enums;
using curumim_api.Application.Ports.Inbound.UseCases.Management.Book;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace curumim_api.Adapters.Inbound.Http.Endpoint.Management.Book
{
    public static class EndpointEditBook
    {
        public static void AddEndpointEditBook(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapPatch("/edit/book", EditBook)
                        .AddEndpointFilter<ValidationFilter<RequestEditBook>>()
                        .Produces<ResponseRegisterBook>(201)
                        .Produces<BaseError>(422)
                        .Produces<BaseError>(500);
            //.RequireAuthorization();

        }

        public static async Task<Results<Created<ResponseEditBook>, BadRequest<BaseError>>>
            EditBook([FromServices] IUseCaseEditBook useCase,
                                [FromQuery] string idempotenceKey,
                                [FromBody] RequestEditBook request)
        {
            var mapper = MapperShared<RequestEditBook>.MapToDomain(request, idempotenceKey);
            var responseUseCase = useCase.Edit(mapper);

            if (responseUseCase.Status != EnumState.SUCCESS) return TypedResults.BadRequest(responseUseCase.ErrorObject!);

            var response = JsonSerializer.Deserialize<ResponseEditBook>(responseUseCase!.SucessObject!.msgOUT!);
            return TypedResults.Created("", response);
        }
    }
}
