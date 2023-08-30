using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Infrastructure.Interfaces.Repository
{
    public interface ILoginRepository
    {
        Task<bool> ValidarCredenciales(string nombre, string contrasenia);
    }
}
