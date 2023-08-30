using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Domain.Entities.Custom
{
    public class Localizacion
    {
        public int IdLocalizacion { get; set; }

        public string NombreLocalizacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int IdUsuarioCreacion { get; set; }

        public int? IdUsuarioModificacion { get; set; }
    }
}
