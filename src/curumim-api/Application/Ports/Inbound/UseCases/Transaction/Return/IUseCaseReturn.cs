using curumim_api.Application.Core.DomainModels;
using curumim_api.Application.Core.DomainModels.Base;

namespace curumim_api.Application.Ports.Inbound.UseCases.Transaction.Return;

public interface IUseCaseReturn
{
    public BaseReturn<DomainModel> Return(DomainModel domainModel);
}