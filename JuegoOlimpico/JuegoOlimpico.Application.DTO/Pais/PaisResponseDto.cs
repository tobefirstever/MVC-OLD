using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Application.DTO.Pais
{
   public class PaisResponseDto
    {
        public int IdPais { get; set; }

        public string NombrePais { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int IdUsuarioCreacion { get; set; }

        public int? IdUsuarioModificacion { get; set; }
    }
}
