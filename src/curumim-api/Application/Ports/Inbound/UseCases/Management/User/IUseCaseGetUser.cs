using curumim_api.Application.Core.DomainModels;
using curumim_api.Application.Core.DomainModels.Base;

namespace curumim_api.Application.Ports.Inbound.UseCases.Management.User
{
    public interface IUseCaseGetUser
    {
        public BaseReturn<DomainModel> Get(DomainModel domainModel);
    }
}
