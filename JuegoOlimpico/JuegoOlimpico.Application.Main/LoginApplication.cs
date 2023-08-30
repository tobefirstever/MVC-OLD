using JuegoOlimpico.Application.Interfaces;
using JuegoOlimpico.Domain.Interfaces;
using JuegoOlimpico.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Application.Main
{
    public class LoginApplication : BaseClass, ILoginApplication
    {
        private readonly ILoginDomain _loginDomain;

        public LoginApplication(ILoginDomain loginDomain)
        {
            _loginDomain = loginDomain;
        }

        public async Task<bool> ValidarCredenciales(string nombre, string contrasenia)
        {
            string contraseniaEncriptada = Seguridad.Encriptar(contrasenia);
            bool resultado = false;
            try
            {
                resultado = await _loginDomain.ValidarCredenciales(nombre, contraseniaEncriptada); 
            }
            catch(Exception exception)
            {
                Logger?.Error(exception, exception.Message);
                resultado = false;
            }

            return resultado;
        }
    }
}
