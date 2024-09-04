using curumim_api.Application.Ports.Inbound.UseCases.Management.Book;
using curumim_api.Application.Ports.Inbound.UseCases.Management.User;
using curumim_api.Application.Ports.Inbound.UseCases.Transaction.Lend;
using curumim_api.Application.Ports.Inbound.UseCases.Transaction.Return;
using curumim_api.Application.UseCase.Management.Book;
using curumim_api.Application.UseCase.Management.User;
using curumim_api.Application.UseCase.Transaction.Lend;
using curumim_api.Application.UseCase.Transaction.Return;

namespace curumim_api.Infra.Configuration
{
    public static class UseCaseConfiguration
    {
        public static void AddUseCaseConfiguration(this IServiceCollection services)
        {
            #region Management
            services.AddScoped<IUseCaseRegisterBook, UseCaseRegisterBook>();
            services.AddScoped<IUseCaseRegisterUser, UseCaseRegisterUser>();
            services.AddScoped<IUseCaseEditUser, UseCaseEditUser>();
            services.AddScoped<IUseCaseEditBook, UseCaseEditBook>();
            services.AddScoped<IUseCaseGetUser, UseCaseGetUser>();
            services.AddScoped<IUseCaseGetBook, UseCaseGetBook>();
            #endregion

            #region Transaction
            services.AddScoped<IUseCaseLend, UseCaseLend>();
            services.AddScoped<IUseCaseReturn, UseCaseReturn>();
            #endregion
        }
    }
}
