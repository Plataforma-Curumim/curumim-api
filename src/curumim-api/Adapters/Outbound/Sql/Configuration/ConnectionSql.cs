using System.Data;
using System.Data.SqlClient;

namespace curumim_api.Adapters.Outbound.Sql.Configuration
{
    public class ConnectionSql
    {
        public class ConnectionString
        {
            public string? Address { get; set; }
            public string? Username { get; set; }
            public string? Database{ get; set; }
            public string? Password { get; set; }

            public IDbConnection ConnectSQLCLUST05(string banco) => new SqlConnection(GetConnectionString());


            public string GetConnectionString()
            {
                this.Address = Environment.GetEnvironmentVariable("DATABASE_ADDRESS");
                this.Username = Environment.GetEnvironmentVariable("DATABASE_USERNAME");
                this.Database = Environment.GetEnvironmentVariable("DATABASE_NAME");
                this.Password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");

                return $"Server={Address};Database={Database};UserId={Username};Password={Password}";
            }

        }

    }
}
