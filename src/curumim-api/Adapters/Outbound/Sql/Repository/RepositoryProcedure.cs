using curumim_api.Application.Core.DomainModels;
using curumim_api.Application.Ports.Outbound.SQL.Connection;
using curumim_api.Application.Ports.Outbound.SQL.Repository;
using Dapper;
using System.Data;

namespace curumim_api.Adapters.Outbound.Sql.Repository
{
    public class RepositoryProcedure(IConnectionSql connection) : IRepositoryProcedure
    {
        private readonly IConnectionSql _connection = connection;

        public async Task<DomainModel> SendAsync(DomainModel domainModel , string _procedureName)
        {
            using (var connection = _connection.ConnectDatabase())
            {
                var parameters = new DynamicParameters();

                parameters.Add("pvchIdempotenceKey", domainModel.idempotenceKey, DbType.String, ParameterDirection.Input, size: 36);
                parameters.Add("pvchMsgIN", domainModel.msgIN, DbType.String, ParameterDirection.Input, size: 8000);

                parameters.Add("pvchMsgOUT", domainModel.msgOUT, DbType.String, ParameterDirection.Output, size: 8000);
                parameters.Add("ptinState", domainModel.state, DbType.Int16, ParameterDirection.Output);
                parameters.Add("pvchMsgErro", domainModel.msgErro, DbType.String, ParameterDirection.Output, size: 8000);


                await connection.ExecuteAsync(_procedureName, parameters, commandType: CommandType.StoredProcedure);

                domainModel.state = parameters.Get<short?>("ptinState");
                domainModel.msgOUT = parameters.Get<string?>("pvchMsgOUT");
                domainModel.msgErro = parameters.Get<string?>("pvchMsgErro");

                return domainModel;
            }
        }
    }
}
