using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Domain.Entities.Custom
{
    public class Sede
    {
        public int IdSede { get; set; }

        public string NombreSede { get; set; }

        public int IdPais { get; set; }

        public string NombrePais { get; set; }

        public int NroComplejos { get; set; }

        public decimal Presupuesto { get; set; }
    }
}
