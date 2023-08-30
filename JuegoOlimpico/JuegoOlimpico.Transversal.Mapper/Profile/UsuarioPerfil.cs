using JuegoOlimpico.Application.DTO.Usuario;
using JuegoOlimpico.Domain.Entities.Custom;


namespace JuegoOlimpico.Transversal.Mapper.Profile
{
   public class UsuarioPerfil : AutoMapper.Profile
    {
        public UsuarioPerfil()
        {
            CreateMap<Usuario, UsuarioResponseDto>()
                ?.ForMember(dest => dest.IdUsuario, opt => opt?.MapFrom(src => src.IdUsuario))
                ?.ForMember(dest => dest.IdUsuarioCreacion, opt => opt?.MapFrom(src => src.IdUsuarioCreacion))
                ?.ForMember(dest => dest.IdUsuarioModificacion, opt => opt?.MapFrom(src => src.IdUsuarioModificacion))
                ?.ForMember(dest => dest.Correo, opt => opt?.MapFrom(src => src.Correo))
                 ?.ForMember(dest => dest.Contrasena, opt => opt?.MapFrom(src => src.Contrasena))
                ?.ForMember(dest => dest.NombreUsuario, opt => opt?.MapFrom(src => src.NombreUsuario))
                ?.ReverseMap();

            CreateMap<Usuario, UsuarioRequestDto>()
               ?.ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.IdUsuario))
               ?.ForMember(dest => dest.Nombre, opt => opt?.MapFrom(src => src.NombreUsuario))
                ?.ForMember(dest => dest.Correo, opt => opt?.MapFrom(src => src.Correo))
                ?.ForMember(dest => dest.Contrasena, opt => opt?.MapFrom(src => src.Contrasena))
               ?.ReverseMap();

        
        }
    }
}
