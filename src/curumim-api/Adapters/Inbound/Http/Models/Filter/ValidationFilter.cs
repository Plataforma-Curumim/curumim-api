using System.Validation;
using curumim_api.Application.Core.DomainModels.Base;
namespace curumim_api.Adapters.Inbound.Http.Models.Filter
{
    public class ValidationFilter<T>(IServiceProvider serviceProvider) : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var validator = serviceProvider.GetRequiredService<IFlatValidator<T>>();

            if (context.Arguments.FirstOrDefault(x =>
                    x?.GetType() == typeof(T)) is not T model)
            {
                return TypedResults.Problem(
                    detail: "Invalid parameter.",
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

            var result = await validator.ValidateAsync(model);
            if (!result)
            {
                var errorResponse = new BaseError("400")
                {
                    mensagem = "Requisição Inválida",

                    erros = new List<Error>()
                };

                foreach (var error in result.Errors)
                {
                    errorResponse.erros.Add(new Error(error.PropertyName, [error.ErrorMessage]));
                }

                return TypedResults.BadRequest(errorResponse);
            }

            return await next(context);
        }

    }
}
