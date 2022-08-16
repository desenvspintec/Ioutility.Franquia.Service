using AutoMapper;
using Ioutility.Franquias.Domain.Franquias.DTOs;
using Ioutility.Franquias.Domain.Franquias.Models;
using Pulsati.Core.Domain.DTOs.ValueObjects;
using Pulsati.Core.Domain.ValueObjects.Enderecos;

namespace Ioutility.Franquias.Domain.Config.Automapper
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<EnderecoVO, EnderecoVODTO>();
            CreateMap<FranquiaDadoBancario, DadoBancarioDTO>();
            CreateMap<Franquia, FranquiaDTO>();
        }
    }
}
