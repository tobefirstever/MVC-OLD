using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JuegoOlimpico.Web.Models
{
    public class SedeModel
    {
        public int IdSede { get; set; }

        public string NombreSede { get; set; }

        public int IdPais { get; set; }

        public string NombrePais { get; set; }

        public int NroComplejos { get; set; }

        public decimal Presupuesto { get; set; }
    }

    public class SedeOlimpicaModel
    {
        public IEnumerable<PaisModel> Paises { get; set; }


        public IEnumerable<SedeModel> Sedes { get; set; }

        public int IdPais { get; set; }

        [Display(Name = "Pais:")]
        public string Pais { get; set; }
    }


    public class RegistrarSedeModel
    {
        public int IdSede { get; set; }

        [Display(Name = "Nombre:")]

        public string NombreSede { get; set; }

        public int IdPais { get; set; }

        [Display(Name = "Pais:")]
        public string NombrePais { get; set; }


        [Display(Name = "Nro Complejos:")]
        public int NroComplejos { get; set; }

        [Display(Name = "Presupuesto:")]
        public decimal Presupuesto { get; set; }

        public IEnumerable<PaisModel> Paises { get; set; }

    }
   
    public class EliminarSedeModel
    {
        public int IdSede { get; set; }
    }


}