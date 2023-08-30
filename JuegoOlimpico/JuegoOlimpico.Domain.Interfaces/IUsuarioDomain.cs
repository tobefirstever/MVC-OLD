using JuegoOlimpico.Domain.Entities.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Domain.Interfaces
{
   public interface IUsuarioDomain
    {
        Task<IEnumerable<Usuario>> Listar();

        Task<IEnumerable<Usuario>> ListarConFiltro(string nombre);

        Task<Usuario> Obtener(int id);

        Task Insertar(Usuario usuario);

        Task Eliminar(int id);

        Task Actualizar(Usuario usuario);
    }
}
