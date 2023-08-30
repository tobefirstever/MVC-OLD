using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JuegoOlimpico.Web.Models
{
    public class UsuarioBusquedaModel
    {
        public string Nombre { get; set; }
    }


    public class UsuarioListadoModel
    {
        public int Id { get; set; }

        public string Usuario { get; set; }

        public string Correo { get; set; }

        public string Contrasena { get; set; }
    }

}