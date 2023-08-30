using JuegoOlimpico.Domain.Interfaces;
using JuegoOlimpico.Infrastructure.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Domain.Main
{
    public class LoginDomain : ILoginDomain
    {
        private readonly ILoginRepository _loginRepository;

        public LoginDomain(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }


        public async Task<bool> ValidarCredenciales(string nombre, string contrasenia)
        {

            return await _loginRepository.ValidarCredenciales(nombre, contrasenia);

        }
    }
}
