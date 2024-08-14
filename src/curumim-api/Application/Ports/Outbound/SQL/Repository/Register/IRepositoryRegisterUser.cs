using curumim_api.Application.Core.DomainModels;

namespace curumim_api.Application.Ports.Outbound.SQL.Repository.Register
{
    public interface IRepositoryRegisterUser
    {
        public Task<DomainModel> Register(DomainModel domainModel);
    }
}
