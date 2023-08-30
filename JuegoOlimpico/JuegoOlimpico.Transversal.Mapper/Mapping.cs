using JuegoOlimpico.Transversal.Mapper.Profile;

namespace JuegoOlimpico.Transversal.Mapper
{
    public static class Mapping
    {
        public static void Inicializate()
        {
            AutoMapper.Mapper.Initialize(x =>
            {
        
                x?.AddProfile<UsuarioPerfil>();
                x?.AddProfile<PaisProfile>();
                x?.AddProfile<SedeProfile>();
            });
        }

        public static TDestino Map<TSource, TDestino>(TSource source, TDestino destino)
        {
            return AutoMapper.Mapper.Map(source, destino);
        }

        public static TDestino Map<TSource, TDestino>(TSource source)
        {
            return AutoMapper.Mapper.Map<TSource, TDestino>(source);
        }
    }
}
