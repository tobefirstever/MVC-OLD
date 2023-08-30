using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JuegoOlimpico.Web.Models
{
    public class UsuarioModel
    {
        public string Nombre { get; set; }

        public string token { get; set; }

        public string Contrasena { get; set; }
    }


    public class UsuarioRegistroModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Contrasena { get; set; }
    }
}