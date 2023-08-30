using Dapper;
using JuegoOlimpico.Domain.Entities.Custom;
using JuegoOlimpico.Infrastructure.Interfaces.Configuration;
using JuegoOlimpico.Infrastructure.Interfaces.Repository;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Infrastructure.Repository.OracleRepository
{
    public class PaisRepository : IPaisRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public PaisRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Pais>> Listar()
        {
            using (var conexion = _connectionFactory?.GetConnection)
            {
                var dynamicParameters = new OracleDynamicParameters();
                dynamicParameters.Add("p_ocLISTA", OracleDbType.RefCursor, ParameterDirection.Output);
                return await conexion.QueryAsync<Pais>("PKGSTP_JLOTEST.USP_LISTAR_PAIS", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
