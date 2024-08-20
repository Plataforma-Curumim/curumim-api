using curumim_api.Application.Core.DomainModels;
using curumim_api.Application.Core.DomainModels.Base;

namespace curumim_api.Application.Ports.Inbound.UseCases.Management.Book
{
    public interface IUseCaseGetBook
    {
        public BaseReturn<DomainModel> Get(DomainModel domainModel);
    }
}
