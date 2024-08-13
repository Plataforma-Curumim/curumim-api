using curumim_api.Application.Ports.Outbound.SQL.Connection;
using System.Data;
using System.Data.SqlClient;

namespace curumim_api.Adapters.Outbound.SQL.Configuration
{
    public class ConnectionSql : IConnectionSql
    {
        private readonly DatabaseConfig _databaseConfig;
        public ConnectionSql()
        {
            _databaseConfig = new DatabaseConfig
            {
                Address = Environment.GetEnvironmentVariable("DATABASE_ADDRESS"),
                Username = Environment.GetEnvironmentVariable("DATABASE_USERNAME"),
                Database = Environment.GetEnvironmentVariable("DATABASE_NAME"),
                Password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD"),
            };
        }
        public IDbConnection ConnectDatabase() => new SqlConnection(_databaseConfig.GetConnectionString());

    }
    public class DatabaseConfig
    {
        public string? Address { get; set; }
        public string? Username { get; set; }
        public string? Database{ get; set; }
        public string? Password { get; set; }

        public string GetConnectionString() =>  $"Server={Address};Database={Database};UserId={Username};Password={Password}";

    }
}
