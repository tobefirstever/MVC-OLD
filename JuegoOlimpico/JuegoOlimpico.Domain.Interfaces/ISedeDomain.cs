using JuegoOlimpico.Domain.Entities.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Domain.Interfaces
{
    public interface ISedeDomain
    {
        Task<IEnumerable<Sede>> Listar();

        Task<Sede> Obtener(int id);

        Task Insertar(Sede sede);

        Task Eliminar(int id);

        Task Actualizar(Sede sede);
    }
}
