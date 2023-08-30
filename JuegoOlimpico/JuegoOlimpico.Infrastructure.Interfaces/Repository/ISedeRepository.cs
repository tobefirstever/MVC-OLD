using JuegoOlimpico.Domain.Entities.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Infrastructure.Interfaces.Repository
{
  public   interface ISedeRepository
    {
        Task<IEnumerable<Sede>> Listar();

        Task<Sede> Obtener(int id);

        Task Insertar(Sede sede);

        Task Actualizar(Sede sede);

        Task Eliminar(int id);
    }
}
