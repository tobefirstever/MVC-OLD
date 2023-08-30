using JuegoOlimpico.Web.Dto.Login;
using JuegoOlimpico.Web.Dto.Usuario;
using JuegoOlimpico.Web.Models;
using JuegoOlimpico.Web.Utilitario;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace JuegoOlimpico.Web.proxy
{
    public class UsuarioProxy
    {
        private readonly WebApiJuegoOlimpico webApiJuegoOlimpico = new WebApiJuegoOlimpico();


        public async Task<UsuarioModel> ValidarCredenciales(LoginViewModel loginViewModel)
        {

            LoginRequestDto loginRequestDto = new LoginRequestDto
            {
                Nombre = loginViewModel.Nombre,
                Contrasena = loginViewModel.Contrasena
            };
           

            var jsonResponse = await webApiJuegoOlimpico.ObtenerToken<LoginRequestDto>(loginRequestDto, Constantes.Usuario.GetToken);

            UsuarioModel usuarioModel = new UsuarioModel
            {
                Nombre = jsonResponse.Username,
                Contrasena = jsonResponse.Contrasena,
                token = jsonResponse.AuthToken
            };

            return usuarioModel;

        }


        public async Task<List<UsuarioListadoModel>> Listar(UsuarioBusquedaModel  usuarioBusquedaModel, string token)
        {
            string jsonResponse = await webApiJuegoOlimpico.EnviarPeticionPost<UsuarioBusquedaModel>(usuarioBusquedaModel, Constantes.Usuario.ListarConFiltro, token);

            var usuarioResponseDtos = JsonConvert.DeserializeObject<Response<List<UsuarioResponseDto>>>(jsonResponse).Data;

            List<UsuarioListadoModel> usuarioListadoModels = usuarioResponseDtos.Select(x => new UsuarioListadoModel
            {
                Id = x.IdUsuario,
                Usuario = x.NombreUsuario,
                Correo = x.Correo

            }).ToList();



            return usuarioListadoModels;
        }

      
        public async Task<UsuarioListadoModel> Obtener(int id, string token)
        {
            string url = $"{Constantes.Usuario.Obtener}{id}";

            string jsonText = await webApiJuegoOlimpico.EnviarPeticionGet(url, token);

            var usuarioResponseDtos = JsonConvert.DeserializeObject<Response<UsuarioResponseDto>>(jsonText).Data;

            UsuarioListadoModel usuarioListadoModel = new UsuarioListadoModel
            {
                Id = usuarioResponseDtos.IdUsuario,
                Usuario = usuarioResponseDtos.NombreUsuario,
                Correo = usuarioResponseDtos.Correo,
                Contrasena = usuarioResponseDtos.Contrasena
            };

            return usuarioListadoModel;
        }


        public async Task<bool> Insertar(UsuarioRegistroModel usuarioRegistroModel , string token )
        {
            string jsonText = await webApiJuegoOlimpico.EnviarPeticionPost<UsuarioRegistroModel>(usuarioRegistroModel, Constantes.Usuario.Crear, token);

            var respuesta = JsonConvert.DeserializeObject<Response<bool>>(jsonText).Data;

            return respuesta;
        }

        public async Task<bool> Actualizar(UsuarioRegistroModel usuarioRegistroModel, string token)
        {
            string url = $"{Constantes.Usuario.Actualizar}{usuarioRegistroModel.Id}";

            string jsonText = await webApiJuegoOlimpico.EnviarPeticionPut<UsuarioRegistroModel>(usuarioRegistroModel, url, token);

            var respuesta = JsonConvert.DeserializeObject<Response<bool>>(jsonText).Data;

            return respuesta;
        }

        public async Task<bool> Eliminar(int id, string token)
        {
            string url = $"{Constantes.Usuario.Eliminar}{id}";

            string jsonText = await webApiJuegoOlimpico.EnviarPeticionDelete(url, token);

            var respuesta = JsonConvert.DeserializeObject<Response<bool>>(jsonText).Data;

            return respuesta;
        }

    }
}