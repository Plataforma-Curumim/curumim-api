using curumim_api.Application.Ports.Inbound.UseCases;
using curumim_api.Application.UseCase;

namespace curumim_api.Infra.Configuration
{
    public static class UseCaseConfiguration
    {
        public static void AddUseCaseConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseRegisterBook, UseCaseRegisterBook>();
        }
    }
}
