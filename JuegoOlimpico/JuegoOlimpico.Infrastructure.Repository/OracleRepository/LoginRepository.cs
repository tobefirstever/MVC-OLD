using Dapper;
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
    public class LoginRepository : ILoginRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public LoginRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> ValidarCredenciales(string nombre, string contrasenia)
        {
            bool resultado = false;

            using (var conexion = _connectionFactory?.GetConnection)
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("p_nombre", value: nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_contrasena", value: contrasenia, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add("p_mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 2000);

                await conexion.ExecuteAsync("PKGSTP_JLOTEST.USP_ACCESO_USU", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                var respuesta = dynamicParameters.Get<string>("p_mensaje");

                if (!string.IsNullOrEmpty(respuesta))
                {
                    resultado = true;
                }
            }


            return resultado;
        }
    }
}
