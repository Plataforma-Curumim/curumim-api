using curumim_api.Application.Core.DomainModels;
using curumim_api.Application.Core.DomainModels.Base;

namespace curumim_api.Application.Ports.Inbound.UseCases.Management.User
{
    public interface IUseCaseEditUser
    {
        public BaseReturn<DomainModel> Edit(DomainModel domainModel);
    }
}
