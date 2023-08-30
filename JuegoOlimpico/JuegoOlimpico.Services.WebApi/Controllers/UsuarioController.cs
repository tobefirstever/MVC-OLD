using JuegoOlimpico.Application.DTO.Usuario;
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
    public class UsuarioController : BaseApiController
    {

        private readonly IUsuarioApplication _usuarioApplication;

        public UsuarioController(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

       
        [HttpGet()]
        [Route("api/usuario")]
        public async Task<IHttpActionResult> Listar()
        {
            return Ok(await _usuarioApplication.Listar());
        }

        [HttpGet()]
        [Route("api/usuario/{id}")]
        public async Task<IHttpActionResult> Obtener(int id)
        {
            return Ok(await _usuarioApplication.Obtener(id));
        }


        [HttpPost()]
        [Route("api/usuario/filtro")]
        public async Task<IHttpActionResult> ListarConFiltro([FromBody] UsuarioBusquedaDto usuarioRequestDto)
        {
            if (usuarioRequestDto == null)
            {
                return BadRequest();
            }

            return Ok(await _usuarioApplication.ListarConFiltro(usuarioRequestDto.Nombre));
        }




        [HttpPost()]
        [Route("api/usuario")]
        public async Task<IHttpActionResult> Insertar([FromBody] UsuarioRequestDto usuarioRequestDto)
        {
            if (usuarioRequestDto == null)
            {
                return BadRequest();
            }

            return Ok(await _usuarioApplication.Insertar(usuarioRequestDto));
        }

        [HttpDelete()]
        [Route("api/usuario/{id}")]
        public async Task<IHttpActionResult> Eliminar(int id)
        {
            var usuarioReturn = await _usuarioApplication.Obtener(id);
            if (usuarioReturn.Data == null)
            {
                return NotFound();
            }

            return Ok(await _usuarioApplication.Eliminar(id));
        }

        [HttpPut()]
        [Route("api/usuario/{id}")]
        public async Task<IHttpActionResult> Actualizar(int id, [FromBody] UsuarioRequestDto usuarioRequestDto)
        {
            if (usuarioRequestDto == null)
            {
                return BadRequest();
            }

            var usuarioReturn = await _usuarioApplication.Obtener(id);
            if (usuarioReturn.Data == null)
            {
                return NotFound();
            }
            usuarioRequestDto.Id = id;
            return Ok(await _usuarioApplication.Actualizar(usuarioRequestDto));
        }

    }
}