using JuegoOlimpico.Application.DTO.Pais;
using JuegoOlimpico.Application.Interfaces;
using JuegoOlimpico.Domain.Entities.Custom;
using JuegoOlimpico.Domain.Interfaces;
using JuegoOlimpico.Transversal.Common;
using JuegoOlimpico.Transversal.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Application.Main
{
    public class PaisApplication : BaseClass, IPaisApplication
    {

        private readonly IPaisDomain _paisDomain;

        public PaisApplication(IPaisDomain paisDomain)
        {
            _paisDomain = paisDomain;
        }

        public async Task<Response<IEnumerable<PaisResponseDto>>> Listar()
        {
            var respuesta = new Response<IEnumerable<PaisResponseDto>> { Data = new List<PaisResponseDto>() };

            try
            {
                IEnumerable<Pais> paisResponseDto = await _paisDomain.Listar();
                respuesta.Data = Mapping.Map<IEnumerable<Pais>, IEnumerable<PaisResponseDto>>(paisResponseDto);
            }
            catch (Exception exception)
            {
                respuesta.IsSuccess = false;
                respuesta.Message = Mensajes.ErrorEnconsulta;
                Logger?.Error(exception, exception.Message);
            }

            return respuesta;
        }
    }
}
