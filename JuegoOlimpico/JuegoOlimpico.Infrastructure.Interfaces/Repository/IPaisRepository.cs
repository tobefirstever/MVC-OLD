using JuegoOlimpico.Domain.Entities.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Infrastructure.Interfaces.Repository
{
   public interface IPaisRepository
    {
        Task<IEnumerable<Pais>> Listar();
    }
}
