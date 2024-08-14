using curumim_api.Application.Core.DomainModels;

namespace curumim_api.Application.Ports.Outbound.SQL.Repository
{
    public interface IRepositoryProcedure
    {
        public Task<DomainModel> SendAsync(DomainModel domainModel, string procedureName);
    }
}
