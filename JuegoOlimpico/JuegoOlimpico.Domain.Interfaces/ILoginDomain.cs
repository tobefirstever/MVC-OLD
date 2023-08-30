using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Domain.Interfaces
{
    public interface ILoginDomain
    {
        Task<bool> ValidarCredenciales(string nombre, string contrasenia);
    }
}
