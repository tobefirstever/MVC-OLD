using JuegoOlimpico.Application.DTO.Usuario;
using JuegoOlimpico.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Application.Interfaces
{
    public interface IUsuarioApplication
    {
        Task<Response<IEnumerable<UsuarioResponseDto>>> Listar();

        Task<Response<IEnumerable<UsuarioResponseDto>>> ListarConFiltro(string nombre);

        Task<Response<UsuarioResponseDto>> Obtener(int id);

        Task<Response<bool>> Insertar(UsuarioRequestDto usuarioRequestDto);

        Task<Response<bool>> Eliminar(int id);

        Task<Response<bool>> Actualizar(UsuarioRequestDto usuarioRequestDto);
    }
}
