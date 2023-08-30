using JuegoOlimpico.Application.DTO.Sede;
using JuegoOlimpico.Domain.Entities.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Transversal.Mapper.Profile
{
    public class SedeProfile : AutoMapper.Profile
    {
        public SedeProfile()
        {
            CreateMap<Sede, SedeResponseDto>()
               ?.ForMember(dest => dest.IdSede, opt => opt?.MapFrom(src => src.IdSede))
               ?.ForMember(dest => dest.NombreSede, opt => opt?.MapFrom(src => src.NombreSede))
               ?.ForMember(dest => dest.IdPais, opt => opt?.MapFrom(src => src.IdPais))
               ?.ForMember(dest => dest.NombrePais, opt => opt?.MapFrom(src => src.NombrePais))
                ?.ForMember(dest => dest.NroComplejos, opt => opt?.MapFrom(src => src.NroComplejos))
               ?.ForMember(dest => dest.Presupuesto, opt => opt?.MapFrom(src => src.Presupuesto))
               ?.ReverseMap();


            CreateMap<Sede, SedeRequestDto>()
              ?.ForMember(dest => dest.IdSede, opt => opt?.MapFrom(src => src.IdSede))
              ?.ForMember(dest => dest.IdPais, opt => opt?.MapFrom(src => src.IdPais))
               ?.ForMember(dest => dest.NombreSede, opt => opt?.MapFrom(src => src.NombreSede))
               ?.ForMember(dest => dest.NroComplejos, opt => opt?.MapFrom(src => src.NroComplejos))
                ?.ForMember(dest => dest.Presupuesto, opt => opt?.MapFrom(src => src.Presupuesto))

              ?.ReverseMap();
        }
    }
}
