using curumim_api.Application.Ports.Inbound.UseCases.Management.Book;
using curumim_api.Application.Ports.Inbound.UseCases.Management.User;
using curumim_api.Application.UseCase.Management.Book;
using curumim_api.Application.UseCase.Management.User;

namespace curumim_api.Infra.Configuration
{
    public static class UseCaseConfiguration
    {
        public static void AddUseCaseConfiguration(this IServiceCollection services)
        {
            #region Management
            services.AddScoped<IUseCaseRegisterBook, UseCaseRegisterBook>();
            services.AddScoped<IUseCaseRegisterUser, UseCaseRegisterUser>();
            #endregion
        }
    }
}
