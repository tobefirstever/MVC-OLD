using JuegoOlimpico.Domain.Entities.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Infrastructure.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> Listar();

        Task<IEnumerable<Usuario>> ListarConFiltro(string nombre);

        Task<Usuario> Obtener(int id);

        Task Insertar(Usuario usuario);

        Task Eliminar(int id);

        Task Actualizar(Usuario usuario);
    }
}
