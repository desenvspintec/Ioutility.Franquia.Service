using AutoMapper;
using Ioutility.Franquias.Domain.Franquias.DTOs;
using Ioutility.Franquias.Domain.Franquias.Models;
using Pulsati.Core.Domain.DTOs.ValueObjects;
using Pulsati.Core.Domain.ValueObjects.Enderecos;

namespace Ioutility.Franquias.Domain.Config.Automapper
{
    public class DTOToDomainProfile : Profile
    {
        public DTOToDomainProfile()
        {
            string nome = "cassiano";
            int numero = 10;
            CreateMap<EnderecoVODTO, EnderecoVO>().ConstructUsing(enderecoDTO => new EnderecoVO(
                enderecoDTO.Complemento,
                enderecoDTO.Numero,
                enderecoDTO.Logradouro,
                enderecoDTO.Bairro,
                enderecoDTO.Cidade,
                enderecoDTO.Estado,
                enderecoDTO.Uf,
                enderecoDTO.Cep,
                enderecoDTO.Arquivos
                ));
            CreateMap<DadoBancarioDTO, FranquiaDadoBancario>().ConstructUsing(dto => new FranquiaDadoBancario(dto.Id));

            CreateMap<FranquiaDTO, Franquia>().ConstructUsing((dto, context)
                => new Franquia(dto.Id, dto.Nome, context.Mapper.Map<EnderecoVO>(dto.Endereco), context.Mapper.Map<FranquiaDadoBancario>(dto.DadoBancario)));
        }
    }
}
