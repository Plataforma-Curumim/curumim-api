using System.Text.Json;
using curumim_api.Adapters.Inbound.Http.Mappers.Shared;
using curumim_api.Adapters.Inbound.Http.Models.Filter;
using curumim_api.Adapters.Inbound.Http.Models.Transaction.Lend;
using curumim_api.Application.Core.DomainModels.Base;
using curumim_api.Application.Core.Enums;
using curumim_api.Application.Ports.Inbound.UseCases.Transaction.Lend;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace curumim_api.Adapters.Inbound.Http.Endpoint.Transaction.Lend;

public static class EndpointLend
{
    public static void AddEndpointLend(this RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost("/lend", Lend)
            .AddEndpointFilter<ValidationFilter<RequestLend>>()
            .Produces<ResponseLend>(200)
            .Produces<BaseError>(422)
            .Produces<BaseError>(500);
        //.RequireAuthorization();

    }
    public static async Task<Results<Ok<ResponseLend>, BadRequest<BaseError>>>
        Lend(
            [FromServices] IUseCaseLend useCase,
            [FromQuery] string idempotenceKey,
            [FromBody] RequestLend request)
    {
        var mapper = MapperShared<RequestLend>.MapToDomain(request, idempotenceKey);
        var responseUseCase = useCase.Lend(mapper);

        if (responseUseCase.Status != EnumState.SUCCESS) return TypedResults.BadRequest(responseUseCase.ErrorObject!);

        var response = JsonSerializer.Deserialize<ResponseLend>(responseUseCase!.SucessObject!.msgOUT!);
        return TypedResults.Ok(response);
    }
}