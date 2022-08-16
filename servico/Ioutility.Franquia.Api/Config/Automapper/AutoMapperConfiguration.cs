using AutoMapper;

namespace Ioutility.Franquias.Api.Config.Automapper
{
    public class AutoMapperConfiguration
    {
        public static IEnumerable<Profile> RegisterMappings()
        {
            return new List<Profile>()
            {
                new ApiDomainToDTOProfile(),
                new ApiDTOToDomainProfile()
            };
        }
    }
}
