using JuegoOlimpico.Infrastructure.Interfaces.Configuration;
using JuegoOlimpico.Transversal.Common;
using System.Data;

namespace JuegoOlimpico.Infrastructure.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _dbConnection;

        public UnitOfWork(IConnectionFactory connectionFactory)
        {
            if (connectionFactory != null) _dbConnection = connectionFactory.GetConnection;
        }

        public IDbTransaction BeginTransaction()
        {
            return _dbConnection?.BeginTransaction();
        }
    }
}
