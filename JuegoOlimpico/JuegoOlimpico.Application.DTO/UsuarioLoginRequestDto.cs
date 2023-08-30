using System.ComponentModel.DataAnnotations;

namespace JuegoOlimpico.Application.DTO
{
    public class UsuarioLoginRequestDto
    {
        [Required(ErrorMessage = "Debe ingresar un valor para nombre")]
        [MaxLength(200, ErrorMessage = "Se permite máximo 200 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un valor para la contraseña")]
        [MaxLength(200, ErrorMessage = "Se permite máximo 200 caracteres")]
        public string Contrasena { get; set; }
    }
}
