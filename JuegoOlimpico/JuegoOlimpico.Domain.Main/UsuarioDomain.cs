using JuegoOlimpico.Domain.Entities.Custom;
using JuegoOlimpico.Domain.Interfaces;
using JuegoOlimpico.Infrastructure.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Domain.Main
{
    public class UsuarioDomain : IUsuarioDomain
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioDomain(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> Listar()
        {

            return await _usuarioRepository.Listar();
        }

        public async Task<IEnumerable<Usuario>> ListarConFiltro(string nombre)
        {
            return await _usuarioRepository.ListarConFiltro(nombre);
        }


        public async Task<Usuario> Obtener(int id)
        {
            return await _usuarioRepository.Obtener(id);
        }

        public async Task Insertar(Usuario usuario)
        {
             await _usuarioRepository.Insertar(usuario);
        }

        public async Task Eliminar(int id)
        {
            await _usuarioRepository.Eliminar(id);
        }

        public async Task Actualizar(Usuario usuario)
        {
            await _usuarioRepository.Actualizar(usuario);
        }
    }
}
