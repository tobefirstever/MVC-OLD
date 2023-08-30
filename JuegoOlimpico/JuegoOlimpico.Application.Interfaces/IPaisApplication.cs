using JuegoOlimpico.Application.DTO.Pais;
using JuegoOlimpico.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Application.Interfaces
{
   public interface IPaisApplication
    {
        Task<Response<IEnumerable<PaisResponseDto>>> Listar();
    }
}
