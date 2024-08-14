using curumim_api.Adapters.Inbound.Http.Endpoint.Management.Book;
using curumim_api.Adapters.Inbound.Http.Endpoint.Management.User;

namespace curumim_api.Infra.Configuration
{
    public static class EndpointConfiguration
    {
        public static void UseEndpointConfiguration(this WebApplication app)
        {
            #region Management
            var managementGroup = app.MapGroup("api/management/");
            managementGroup.AddEndpointRegisterBook();
            managementGroup.AddEndpointRegisterUser();
            managementGroup.AddEndpointEditUser();
            #endregion
        }
    }
}
