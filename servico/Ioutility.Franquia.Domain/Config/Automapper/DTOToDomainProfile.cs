using AutoMapper;
using Ioutility.Franquias.Domain.Franquias.DTOs;
using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Domain.Procedimentos.DTOs;
using Ioutility.Franquias.Domain.Procedimentos.Models;
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

            CreateMap<FranquiaDTO, Franquia>().ConstructUsing((dto, context)
                => new Franquia(dto.Id, dto.Nome, context.Mapper.Map<EnderecoVO>(dto.Endereco), context.Mapper.Map<FranquiaDadoBancario>(dto.DadoBancario)));


            CreateMap<TipoProcedimentoDTO, TipoProcedimento>().
                ConstructUsing(dto => new TipoProcedimento(dto.Id, dto.Nome));
            CreateMap<ProcedimentoDTO, Procedimento>().
                ConstructUsing(dto => new Procedimento(
                    dto.Id, 
                    dto.Especialidade, 
                    dto.TipoProcedimentoId,
                    new ProcedimentoValorVO(dto.ValorSugerido, dto.ValorMinimo, dto.ValorMaximo, dto.ValorCustoAdicional),
                    new ProcedimentoComissaoVO(dto.ComissaoTipo, dto.ComissaoValor)
                    )
                );
        }
    }
}
