using curumim_api.Adapters.Inbound.Http.Endpoint.Management.Book;
using curumim_api.Adapters.Inbound.Http.Endpoint.Management.User;
using curumim_api.Adapters.Inbound.Http.Endpoint.Transaction.Lend;

namespace curumim_api.Infra.Configuration
{
    public static class EndpointConfiguration
    {
        public static void UseEndpointConfiguration(this WebApplication app)
        {
            #region Management
            var managementGroup = app.MapGroup("api/management/").WithTags("Gestão");
            managementGroup.AddEndpointRegisterBook();
            managementGroup.AddEndpointRegisterUser();
            managementGroup.AddEndpointEditUser();
            managementGroup.AddEndpointEditBook();
            managementGroup.AddEndpointGetUser();
            managementGroup.AddEndpointGetBook();
            #endregion

            #region Transaction
            var transactionGroup = app.MapGroup("api/transaction/").WithTags("Transação");
            transactionGroup.AddEndpointLend();
            #endregion
        }
    }
}
