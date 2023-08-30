using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JuegoOlimpico.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "* Debe ingresar un usuario")]
        [Display(Name = "Usuario")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "* Debe ingresar una contraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }

        //public string NombreEncrypt { get; set; }

        //public string ContrasenaEncrypt { get; set; }
    }
}