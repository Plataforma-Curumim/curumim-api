using System.Text.Json;
using curumim_api.Adapters.Inbound.Http.Mappers.Shared;
using curumim_api.Adapters.Inbound.Http.Models.Filter;
using curumim_api.Adapters.Inbound.Http.Models.Transaction.Return;
using curumim_api.Application.Core.DomainModels.Base;
using curumim_api.Application.Core.Enums;
using curumim_api.Application.Ports.Inbound.UseCases.Transaction.Return;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace curumim_api.Adapters.Inbound.Http.Endpoint.Transaction.Return;

public static class EndpointReturn
{
    public static void AddEndpointReturn(this RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost("/return", Return)
            .AddEndpointFilter<ValidationFilter<RequestReturn>>()
            .Produces<ResponseReturn>(200)
            .Produces<BaseError>(422)
            .Produces<BaseError>(500);
        //.RequireAuthorization();
    }
    public static async Task<Results<Ok<ResponseReturn>, BadRequest<BaseError>>>
        Return(
            [FromServices] IUseCaseReturn useCase,
            [FromQuery] string idempotenceKey,
            [FromBody] RequestReturn request)
    {
        var mapper = MapperShared<RequestReturn>.MapToDomain(request, idempotenceKey);
        var responseUseCase = useCase.Return(mapper);

        if (responseUseCase.Status != EnumState.SUCCESS) return TypedResults.BadRequest(responseUseCase.ErrorObject!);

        var response = JsonSerializer.Deserialize<ResponseReturn>(responseUseCase!.SucessObject!.msgOUT!);
        return TypedResults.Ok(response);
    }
}