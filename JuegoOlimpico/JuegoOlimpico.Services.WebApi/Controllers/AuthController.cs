using System.Threading.Tasks;
using System.Web.Http;
using JuegoOlimpico.Application.DTO;
using JuegoOlimpico.Application.Interfaces;
using JuegoOlimpico.Services.WebApi.Core;

namespace JuegoOlimpico.Services.WebApi.Controllers
{
    /// <summary>
    /// Controlador que contiene todas las apis de Autenticación
    /// </summary>    
    public class AuthController : ApiController
    {

        private readonly ILoginApplication _loginApplication;

        public AuthController(ILoginApplication loginApplication)
        {
            _loginApplication = loginApplication;
        }


        [HttpPost()]
        [Route("api/auth")]
        public async Task<IHttpActionResult> Login([FromBody] UsuarioLoginRequestDto usuarioLoginDto)
        {
            string token = string.Empty;
            if (usuarioLoginDto == null)
            {
                return BadRequest();
            }

            bool esvalido = await _loginApplication.ValidarCredenciales(usuarioLoginDto.Nombre, usuarioLoginDto.Contrasena.Trim());

            if (esvalido)
            {
                token = TokenGenerator.GenerateTokenJwt(usuarioLoginDto.Nombre);
                return Ok(
                    new Transversal.Common.Response<UsuarioLoginResponseDto>
                    {
                        Data = new UsuarioLoginResponseDto
                        {
                            Username = usuarioLoginDto.Nombre,
                            AuthToken = token,
                            Contrasena = usuarioLoginDto.Contrasena
                        }
                    });
            }
            else
            {
                return Unauthorized();
            }


        }
    }
}