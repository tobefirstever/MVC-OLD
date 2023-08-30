using JuegoOlimpico.Application.DTO.Usuario;
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
using System.Transactions;

namespace JuegoOlimpico.Application.Main
{
    public class UsuarioApplication : BaseClass, IUsuarioApplication
    {
        private readonly IUsuarioDomain _usuarioDomain;

        public UsuarioApplication(IUsuarioDomain usuarioDomain)
        {
            _usuarioDomain = usuarioDomain;
        }

        public async Task<Response<IEnumerable<UsuarioResponseDto>>> Listar()
        {
            var respuesta = new Response<IEnumerable<UsuarioResponseDto>> { Data = new List<UsuarioResponseDto>() };

            try
            {
                IEnumerable<Usuario> usuarioResponseDtos = await _usuarioDomain.Listar();
                respuesta.Data = Mapping.Map<IEnumerable<Usuario>, IEnumerable<UsuarioResponseDto>>(usuarioResponseDtos);
            }
            catch (Exception exception)
            {
                respuesta.IsSuccess = false;
                respuesta.Message = Mensajes.ErrorEnconsulta;
                Logger?.Error(exception, exception.Message);
            }

            return respuesta;
        }

        public async Task<Response<IEnumerable<UsuarioResponseDto>>> ListarConFiltro(string nombre)
        {
            var respuesta = new Response<IEnumerable<UsuarioResponseDto>> { Data = new List<UsuarioResponseDto>() };

            try
            {
                IEnumerable<Usuario> usuarioResponseDtos = await _usuarioDomain.ListarConFiltro(nombre);
                respuesta.Data = Mapping.Map<IEnumerable<Usuario>, IEnumerable<UsuarioResponseDto>>(usuarioResponseDtos);
            }
            catch (Exception exception)
            {
                respuesta.IsSuccess = false;
                respuesta.Message = Mensajes.ErrorEnconsulta;
                Logger?.Error(exception, exception.Message);
            }

            return respuesta;
        }

        public async Task<Response<UsuarioResponseDto>> Obtener(int id)
        {
            var respuesta = new Response<UsuarioResponseDto> { Data = new UsuarioResponseDto() };

            try
            {
                Usuario usuario = await _usuarioDomain.Obtener(id);

                respuesta.Data = Mapping.Map<Usuario, UsuarioResponseDto>(usuario);
            }
            catch (Exception exception)
            {
                respuesta.IsSuccess = false;
                respuesta.Message = Mensajes.ErrorEnconsulta;
                Logger?.Error(exception, exception.Message);
            }
            return respuesta;

        }

        public async Task<Response<bool>> Insertar(UsuarioRequestDto usuarioRequestDto)
        {
            var response = new Response<bool>();

            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TimeSpan.FromTicks(Constantes.TimeoutTransaccion),
            };

            using (var transaccion = new TransactionScope(TransactionScopeOption.Required, options, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (usuarioRequestDto == null)
                    {
                        response.IsWarning = true;
                        response.Message = Mensajes.ErrorAlRegistrarDataInvalida;
                        return response;
                    }

                    usuarioRequestDto.Contrasena = Seguridad.Encriptar(usuarioRequestDto.Contrasena);

                    if (_usuarioDomain != null)
                        await _usuarioDomain?.Insertar(
                            Mapping.Map<UsuarioRequestDto, Usuario>(usuarioRequestDto));
                    response.Data = true;
                    transaccion.Complete();
                }
                catch (Exception exception)
                {
                    response.IsSuccess = false;
                    response.Message = Mensajes.ErrorEnconsulta;
                    Logger?.Error(exception, exception.Message);
                }
            }



            return response;
        }

        public async Task<Response<bool>> Eliminar(int id)
        {
            var response = new Response<bool>();

            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TimeSpan.FromTicks(Constantes.TimeoutTransaccion),
            };
            using (var transaccion = new TransactionScope(TransactionScopeOption.Required, options, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (_usuarioDomain != null) await _usuarioDomain?.Eliminar(id);
                    response.Data = true;
                    transaccion.Complete();
                }
                catch (Exception exception)
                {
                    response.IsSuccess = false;
                    response.Message = Mensajes.ErrorEnconsulta;
                    Logger?.Error(exception, exception.Message);
                }
            }



            return response;

        }

        public async Task<Response<bool>> Actualizar(UsuarioRequestDto usuarioRequestDto)
        {
            var response = new Response<bool>();

            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TimeSpan.FromTicks(Constantes.TimeoutTransaccion),
            };

            using (var transaccion = new TransactionScope(TransactionScopeOption.Required, options, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (usuarioRequestDto == null)
                    {
                        response.IsWarning = true;
                        response.Message = Mensajes.ErrorAlRegistrarDataInvalida;
                        return response;
                    }

                    usuarioRequestDto.Contrasena = Seguridad.Encriptar(usuarioRequestDto.Contrasena);

                    if (_usuarioDomain != null)
                        await _usuarioDomain?.Actualizar(
                            Mapping.Map<UsuarioRequestDto, Usuario>(usuarioRequestDto));
                    response.Data = true;
                    transaccion.Complete();
                }
                catch (Exception exception)
                {
                    response.IsSuccess = false;
                    response.Message = Mensajes.ErrorEnconsulta;
                    Logger?.Error(exception, exception.Message);
                }
            }



            return response;
        }
    }
}
