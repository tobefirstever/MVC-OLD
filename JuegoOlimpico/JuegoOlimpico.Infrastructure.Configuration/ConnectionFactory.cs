using System.Configuration;
using System.Data;
using System.Data.Common;
using JuegoOlimpico.Infrastructure.Interfaces.Configuration;
using JuegoOlimpico.Transversal.Common;

namespace JuegoOlimpico.Infrastructure.Configuration
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings?[Constantes.Demo]?.ConnectionString;

        public IDbConnection GetConnection
        {
            get
            {
                var factory = DbProviderFactories.GetFactory(Constantes.OracleClient);
                var conn = factory.CreateConnection();

                if (conn == null) return null;

                conn.ConnectionString = _connectionString;
                conn.Open();
                return conn;
            }
        }
    }
}
