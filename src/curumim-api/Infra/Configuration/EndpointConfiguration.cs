using curumim_api.Adapters.Inbound.Http.Endpoint.Register;

namespace curumim_api.Infra.Configuration
{
    public static class EndpointConfiguration
    {
        public static void UseEndpointConfiguration(this WebApplication app)
        {
            #region Register
            var registerGroup = app.MapGroup("api/register/");
            registerGroup.AddEndpointRegisterBook();
            registerGroup.AddEndpointRegisterUser();
            #endregion
        }
    }
}
