using curumim_api.Application.Core.DomainModels.Base;
using curumim_api.Application.Core.DomainModels;

namespace curumim_api.Application.Ports.Inbound.UseCases.Management.Book
{
    public interface IUseCaseEditBook
    {
        public BaseReturn<DomainModel> Edit(DomainModel domainModel);
    }
}
