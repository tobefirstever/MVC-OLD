using System.Data;

namespace JuegoOlimpico.Infrastructure.Interfaces.Configuration
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
