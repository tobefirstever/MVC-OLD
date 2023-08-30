using JuegoOlimpico.Application.DTO.Pais;
using JuegoOlimpico.Domain.Entities.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Transversal.Mapper.Profile
{
    public class PaisProfile : AutoMapper.Profile
    {
        public PaisProfile()
        {
            CreateMap<Pais, PaisResponseDto>()
                ?.ForMember(dest => dest.IdPais, opt => opt?.MapFrom(src => src.IdPais))
                ?.ForMember(dest => dest.NombrePais, opt => opt?.MapFrom(src => src.NombrePais))
                ?.ForMember(dest => dest.FechaCreacion, opt => opt?.MapFrom(src => src.FechaCreacion))
                ?.ForMember(dest => dest.FechaModificacion, opt => opt?.MapFrom(src => src.FechaModificacion))
                 ?.ForMember(dest => dest.IdUsuarioCreacion, opt => opt?.MapFrom(src => src.IdUsuarioCreacion))
                ?.ForMember(dest => dest.IdUsuarioModificacion, opt => opt?.MapFrom(src => src.IdUsuarioModificacion))
                ?.ReverseMap();
        }
    }
}
