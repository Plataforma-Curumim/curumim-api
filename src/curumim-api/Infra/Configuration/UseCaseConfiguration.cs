using curumim_api.Application.Ports.Inbound.UseCases.Register;
using curumim_api.Application.UseCase.Register;

namespace curumim_api.Infra.Configuration
{
    public static class UseCaseConfiguration
    {
        public static void AddUseCaseConfiguration(this IServiceCollection services)
        {
            #region Register
            services.AddScoped<IUseCaseRegisterBook, UseCaseRegisterBook>();
            services.AddScoped<IUseCaseRegisterUser, UseCaseRegisterUser>();
            #endregion
        }
    }
}
