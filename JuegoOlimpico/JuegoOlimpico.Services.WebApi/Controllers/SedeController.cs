using JuegoOlimpico.Application.DTO.Sede;
using JuegoOlimpico.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace JuegoOlimpico.Services.WebApi.Controllers
{
    
    public class SedeController : ApiController
    {
        private readonly ISedeApplication _sedeApplication;

        public SedeController(ISedeApplication sedeApplication)
        {
            _sedeApplication = sedeApplication;
        }

        [HttpGet()]
        [Route("api/sede")]
        public async Task<IHttpActionResult> Listar()
        {
            return Ok(await _sedeApplication.Listar());
        }


        [HttpGet()]
        [Route("api/sede/{id}")]
        public async Task<IHttpActionResult> Obtener(int id)
        {
            return Ok(await _sedeApplication.Obtener(id));
        }

        [HttpPost()]
        [Route("api/sede")]
        public async Task<IHttpActionResult> Insertar([FromBody] SedeRequestDto sedeRequestDto)
        {
            if (sedeRequestDto == null)
            {
                return BadRequest();
            }

            return Ok(await _sedeApplication.Insertar(sedeRequestDto));
        }

        [HttpDelete()]
        [Route("api/sede/{id}")]
        public async Task<IHttpActionResult> Eliminar(int id)
        {
            var usuarioReturn = await _sedeApplication.Obtener(id);
            if (usuarioReturn.Data == null)
            {
                return NotFound();
            }

            return Ok(await _sedeApplication.Eliminar(id));
        }

        [HttpPut()]
        [Route("api/sede/{id}")]
        public async Task<IHttpActionResult> Actualizar(int id, [FromBody] SedeRequestDto sedeRequestDto)
        {
            if (sedeRequestDto == null)
            {
                return BadRequest();
            }

            var usuarioReturn = await _sedeApplication.Obtener(id);
            if (usuarioReturn.Data == null)
            {
                return NotFound();
            }
            sedeRequestDto.IdSede = id;
            return Ok(await _sedeApplication.Actualizar(sedeRequestDto));
        }

    }
}