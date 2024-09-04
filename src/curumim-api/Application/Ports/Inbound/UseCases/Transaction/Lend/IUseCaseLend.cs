using curumim_api.Application.Core.DomainModels;
using curumim_api.Application.Core.DomainModels.Base;

namespace curumim_api.Application.Ports.Inbound.UseCases.Transaction.Lend;

public interface IUseCaseLend
{
    public BaseReturn<DomainModel> Lend(DomainModel domainModel);
}