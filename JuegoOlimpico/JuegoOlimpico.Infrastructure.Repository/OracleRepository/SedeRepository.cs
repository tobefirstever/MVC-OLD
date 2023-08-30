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
    public class SedeRepository : ISedeRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public SedeRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Sede>> Listar()
        {
            using (var conexion = _connectionFactory?.GetConnection)
            {
                var dynamicParameters = new OracleDynamicParameters();
                dynamicParameters.Add("p_ocLISTA", OracleDbType.RefCursor, ParameterDirection.Output);
                return await conexion.QueryAsync<Sede>("PKGSTP_JLOTEST.USP_LISTAR_SEDE", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Sede> Obtener(int id)
        {

            using (var conexion = _connectionFactory?.GetConnection)
            {
                var dynamicParameters = new OracleDynamicParameters();
                dynamicParameters.Add("p_id", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_ocLISTA", OracleDbType.RefCursor, ParameterDirection.Output);


                return await conexion.QueryFirstOrDefaultAsync<Sede>("PKGSTP_JLOTEST.USP_OBTENER_SEDE", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }

        }

        public async Task Insertar(Sede sede)
        {
            using (var conexion = _connectionFactory?.GetConnection)
            {
                var dynamicParameters = new OracleDynamicParameters();
                if (sede == null) return;

                dynamicParameters.Add("p_nombre", value: sede.NombreSede, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_idPais", value: sede.IdPais, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_nroComplejos", value: sede.NroComplejos, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_presupuesto", value: sede.Presupuesto, dbType: DbType.Decimal, direction: ParameterDirection.Input);

                await conexion.ExecuteAsync("PKGSTP_JLOTEST.USP_INSERTAR_SEDE", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Actualizar(Sede sede)
        {
            using (var conexion = _connectionFactory?.GetConnection)
            {
                var dynamicParameters = new OracleDynamicParameters();
                if (sede == null) return;

                dynamicParameters.Add("p_id", value: sede.IdSede, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_nombre", value: sede.NombreSede, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_idPais", value: sede.IdPais, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_nroComplejos", value: sede.NroComplejos, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_presupuesto", value: sede.Presupuesto, dbType: DbType.Decimal, direction: ParameterDirection.Input);

                await conexion.ExecuteAsync("PKGSTP_JLOTEST.USP_ACTUALIZAR_SEDE", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Eliminar(int id)
        {
            using (var conexion = _connectionFactory?.GetConnection)
            {
                var dynamicParameters = new OracleDynamicParameters();
                dynamicParameters.Add("p_id", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                await conexion.ExecuteAsync("PKGSTP_JLOTEST.USP_ELIMINAR_SEDE", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
