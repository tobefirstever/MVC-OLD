using JuegoOlimpico.Application.DTO.Sede;
using JuegoOlimpico.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Application.Interfaces
{
   public interface ISedeApplication
    {
        Task<Response<IEnumerable<SedeResponseDto>>> Listar();

        Task<Response<SedeResponseDto>> Obtener(int id);

        Task<Response<bool>> Insertar(SedeRequestDto sedeRequestDto);

        Task<Response<bool>> Eliminar(int id);

        Task<Response<bool>> Actualizar(SedeRequestDto sedeRequestDto);


    }
}
