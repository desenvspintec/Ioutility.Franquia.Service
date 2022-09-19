using AutoMapper;
using Ioutility.Franquias.Domain.Config.Automapper;

namespace Pulsati.Core.Tests.UnidadeTests.Config.Singleton
{
    public class AutoMapperProfiles
    {
        private static IMapper? _automapper = null;

        public static IMapper ObterAutoMapper()
        {
            if (_automapper != null) return _automapper;

            _automapper = new MapperConfiguration(config =>
            {
                config.AddProfile<DTOToDomainProfile>();
                config.AddProfile<DomainToDTOProfile>();
            }).CreateMapper();            

            return _automapper;
        }
    }
}
