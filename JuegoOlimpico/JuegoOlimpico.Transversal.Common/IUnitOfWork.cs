using System.Data;

namespace JuegoOlimpico.Transversal.Common
{
    public interface IUnitOfWork
    {
        IDbTransaction BeginTransaction();
    }
}
