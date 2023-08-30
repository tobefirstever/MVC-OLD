using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Web.Dto.Login
{
    public class LoginResponseDto
    {
        public string Username { get; set; }
        public string Contrasena { get; set; }
        public string AuthToken { get; set; }
    }
}
