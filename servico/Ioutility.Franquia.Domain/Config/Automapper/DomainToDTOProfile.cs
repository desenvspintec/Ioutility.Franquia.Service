using AutoMapper;
using Ioutility.Franquias.Domain.Franquias.DTOs;
using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Domain.Procedimentos.DTOs;
using Ioutility.Franquias.Domain.Procedimentos.Models;
using Pulsati.Core.Domain.DTOs.ValueObjects;
using Pulsati.Core.Domain.ValueObjects.Enderecos;

namespace Ioutility.Franquias.Domain.Config.Automapper
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<EnderecoVO, EnderecoVODTO>();
            CreateMap<FranquiaDadoBancario, FranquiaDadoBancario>();
            CreateMap<Franquia, FranquiaDTO>();
            CreateMap<Procedimento, ProcedimentoDTO>();
            CreateMap<TipoProcedimento, TipoProcedimentoDTO>();
        }
    }
}
