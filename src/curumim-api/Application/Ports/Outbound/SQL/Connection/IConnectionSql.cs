using System.Data;

namespace curumim_api.Application.Ports.Outbound.SQL.Connection
{
    public interface IConnectionSql
    {
        public IDbConnection ConnectDatabase();
    }
}
