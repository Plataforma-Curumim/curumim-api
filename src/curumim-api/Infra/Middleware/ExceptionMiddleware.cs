using curumim_api.Application.Core.DomainModels.Base;

namespace curumim_api.Infra.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

                var error = new BaseError("500")
                {
                    mensagem = exception.Message
                };

                context.Response.StatusCode =
                    StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
