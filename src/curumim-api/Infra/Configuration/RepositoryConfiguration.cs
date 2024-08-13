using curumim_api.Adapters.Outbound.SQL.Configuration;
using curumim_api.Adapters.Outbound.SQL.Repository;
using curumim_api.Application.Ports.Outbound.SQL.Connection;
using curumim_api.Application.Ports.Outbound.SQL.Repository;

namespace curumim_api.Infra.Configuration
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionSql, ConnectionSql>();
            services.AddScoped<IRepositoryRegisterBook, RepositoryRegisterBook>();
        }
    }
}
