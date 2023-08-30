using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Application.Interfaces
{
    public interface ILoginApplication
    {
        Task<bool> ValidarCredenciales(string nombre, string contrasenia);
    }
}
