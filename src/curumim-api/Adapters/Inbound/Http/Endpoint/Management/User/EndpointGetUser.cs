﻿using curumim_api.Adapters.Inbound.Http.Mappers.Shared;
using curumim_api.Adapters.Inbound.Http.Models.Management.User.GetUser;
using curumim_api.Application.Core.DomainModels.Base;
using curumim_api.Application.Core.Enums;
using curumim_api.Application.Ports.Inbound.UseCases.Management.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace curumim_api.Adapters.Inbound.Http.Endpoint.Management.User
{
    public static class EndpointGetUser
    {
        public static void AddEndpointGetUser(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapGet("/get/user", GetUser)
                        .Produces<ResponseGetUser>(200)
                        .Produces<BaseError>(422)
                        .Produces<BaseError>(500);
            //.RequireAuthorization();

        }

        public static async Task<Results<Ok<ResponseGetUser>, BadRequest<BaseError>>>
            GetUser(            [FromServices] IUseCaseGetUser useCase,
                                [FromBody] RequestGetUser request)
        {
            var mapper = MapperShared<RequestGetUser>.MapToDomain(request, "");
            var responseUseCase = useCase.Get(mapper);

            if (responseUseCase.Status != EnumState.SUCCESS) return TypedResults.BadRequest(responseUseCase.ErrorObject!);

            var response = JsonSerializer.Deserialize<ResponseGetUser>(responseUseCase!.SucessObject!.msgOUT!);
            return TypedResults.Ok(response);
        }
    }
}
