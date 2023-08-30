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
    public class PaisDomain : IPaisDomain
    {
        private readonly IPaisRepository _paisRepository;

        public PaisDomain(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }

        public async Task<IEnumerable<Pais>> Listar()
        {
            return await _paisRepository.Listar();
        }
    }
}
