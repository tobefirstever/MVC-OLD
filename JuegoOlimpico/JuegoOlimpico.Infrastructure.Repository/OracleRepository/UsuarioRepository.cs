using JuegoOlimpico.Domain.Entities.Custom;
using JuegoOlimpico.Infrastructure.Interfaces.Configuration;
using JuegoOlimpico.Infrastructure.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace JuegoOlimpico.Infrastructure.Repository.OracleRepository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UsuarioRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Usuario>> Listar()
        {
            using (var conexion = _connectionFactory?.GetConnection)
            {
                var dynamicParameters = new OracleDynamicParameters();
                dynamicParameters.Add("p_nombre", value: null, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_ocLISTA", OracleDbType.RefCursor, ParameterDirection.Output);
                return await conexion.QueryAsync<Usuario>("PKGSTP_JLOTEST.USP_LISTAR_USUARIO", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Usuario>> ListarConFiltro(string nombre)
        {
            using (var conexion = _connectionFactory?.GetConnection)
            {
                var dynamicParameters = new OracleDynamicParameters();
                dynamicParameters.Add("p_nombre", value: nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_ocLISTA", OracleDbType.RefCursor, ParameterDirection.Output);
                return await conexion.QueryAsync<Usuario>("PKGSTP_JLOTEST.USP_LISTAR_USUARIO", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Usuario> Obtener(int id)
        {

            using (var conexion = _connectionFactory?.GetConnection)
            {
                var dynamicParameters = new OracleDynamicParameters();
                dynamicParameters.Add("p_id", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_ocLISTA", OracleDbType.RefCursor, ParameterDirection.Output);


                return await conexion.QueryFirstOrDefaultAsync<Usuario>("PKGSTP_JLOTEST.USP_OBTENER_USUARIO", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }

        }

        public async Task Insertar(Usuario usuario)
        {
            using (var conexion = _connectionFactory?.GetConnection)
            {
                var dynamicParameters = new OracleDynamicParameters();
                if (usuario == null) return;

                dynamicParameters.Add("p_nombre", value:usuario.NombreUsuario,dbType:DbType.String,direction:ParameterDirection.Input);
                dynamicParameters.Add("p_correo", value: usuario.Correo, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_idUsuarioCreacion", value: usuario.IdUsuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_contrasena", value: usuario.Contrasena, dbType: DbType.String, direction: ParameterDirection.Input);

                await conexion.ExecuteAsync("PKGSTP_JLOTEST.USP_INSERTAR_USUARIO", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Eliminar(int id)
        {
            using (var conexion = _connectionFactory?.GetConnection)
            {
                var dynamicParameters = new OracleDynamicParameters();
                dynamicParameters.Add("p_id", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                await conexion.ExecuteAsync("PKGSTP_JLOTEST.USP_ELIMINAR_USUARIO", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Actualizar(Usuario usuario)
        {
            using (var conexion = _connectionFactory?.GetConnection)
            {
                var dynamicParameters = new OracleDynamicParameters();
                if (usuario == null) return;

                dynamicParameters.Add("p_id", value: usuario.IdUsuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_nombre", value: usuario.NombreUsuario, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_correo", value: usuario.Correo, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_contrasena", value: usuario.Contrasena, dbType: DbType.String, direction: ParameterDirection.Input);

                await conexion.ExecuteAsync("PKGSTP_JLOTEST.USP_ACTUALIZAR_USUARIO", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
