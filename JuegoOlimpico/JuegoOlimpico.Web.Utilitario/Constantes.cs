using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Web.Utilitario
{
    public static class Constantes
    {
        public static class Usuario
        {
            public const string GetToken = "api/auth";

            public const string ValidarUsuario = "api/usuario";

            public const string Listar = "api/usuario";

            public const string ListarConFiltro = "api/usuario/filtro";

            public const string Obtener = "api/usuario/";

            public const string Crear = "api/usuario";

            public const string Eliminar = "api/usuario/";

            public const string Actualizar = "api/usuario/";
        }

        public static class Pais
        {
            public const string Listar = "api/pais";
        }

        public static class Sede
        {
            public const string Listar = "api/sede";

            public const string Obtener = "api/sede/";  ///api/sede/{id

            public const string Crear = "api/sede";

            public const string Eliminar = "api/sede/"; /// api/sede/{id}

            public const string Actualizar = "api/sede/"; ///api/sede/{id}
        }
    }
}
