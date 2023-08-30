using JuegoOlimpico.Domain.Entities.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Domain.Interfaces
{
    public interface IPaisDomain
    {
        Task<IEnumerable<Pais>> Listar();
    }
}
