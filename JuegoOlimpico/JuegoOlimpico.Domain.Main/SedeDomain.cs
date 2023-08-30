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
    public class SedeDomain : ISedeDomain
    {
        private readonly ISedeRepository _sedeRepository;

        public SedeDomain(ISedeRepository sedeRepository)
        {
            _sedeRepository = sedeRepository;
        }

        public async Task<IEnumerable<Sede>> Listar()
        {
            return await _sedeRepository.Listar();
        }

        public async Task<Sede> Obtener(int id)
        {
            return await _sedeRepository.Obtener(id);
        }

        public async Task Insertar(Sede sede)
        {
            await _sedeRepository.Insertar(sede);
        }

        public async Task Eliminar(int id)
        {
            await _sedeRepository.Eliminar(id);
        }

        public async Task Actualizar(Sede sede)
        {
            await _sedeRepository.Actualizar(sede);
        }
    }
}
