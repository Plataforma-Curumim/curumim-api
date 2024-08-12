using curumim_api.Adapters.Inbound.Http.Endpoint.RegisterBook;

namespace curumim_api.Infra.Configuration
{
    public static class EndpointConfiguration
    {
        public static void UseEndpointConfiguration(this WebApplication app)
        {
            var registerGroup = app.MapGroup("api/register");

            registerGroup.AddEndpointRegisterBook();
        }
    }
}
