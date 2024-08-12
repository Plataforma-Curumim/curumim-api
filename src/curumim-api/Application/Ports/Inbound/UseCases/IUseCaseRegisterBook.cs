using curumim_api.Application.Core.DomainModels;
using curumim_api.Application.Core.DomainModels.Base;

namespace curumim_api.Application.Ports.Inbound.UseCases
{
    public interface IUseCaseRegisterBook
    {
        public BaseReturn<DomainModel> Register(DomainModel domainModel);
    }
}
