﻿using AutoMapper;
using Ioutility.Franquias.Domain.Franquias.DTOs;
using Ioutility.Franquias.Domain.Franquias.DTOs.Gerais;
using Ioutility.Franquias.Domain.Franquias.Models;
using Pulsati.Core.Domain.DTOs.ValueObjects;
using Pulsati.Core.Domain.ValueObjects.Enderecos;

namespace Ioutility.Franquias.Domain.Config.Automapper
{
    public class DTOToDomainProfile : Profile
    {
        public DTOToDomainProfile()
        {
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

            CreateMap<DadosBancariosVODTO, FranquiaDadoBancario>().ConstructUsing((dto, context) =>
                 new FranquiaDadoBancario(dto.BancoId, dto.Agencia, dto.Conta, dto.TipoChavePix, dto.ChavePix));

            CreateMap<FranquiaAcessoVODTO, FranquiaAcessoVO>().ConstructUsing((dto, context) =>
                new FranquiaAcessoVO(dto.FranquiaStatus));

            CreateMap<FranquiaDTO, Franquia>().ConstructUsing((dto, context) =>
                 new Franquia(dto.Id, dto.Nome, dto.RazaoSocial, dto.Matricula, dto.Cnpj, dto.ResponsavelLegal,
                 dto.Email, dto.Telefone, dto.CelularWhatsApp,
                 context.Mapper.Map<EnderecoVO>(dto.Endereco),
                 context.Mapper.Map<FranquiaDadoBancario>(dto.DadosBancarios),
                 //context.Mapper.Map<FranquiaBusinessPay>(dto.FranquiaBusinessPay),
                 context.Mapper.Map<FranquiaAcessoVO>(dto.FranquiaAcesso)
                 ));
        }
    }
}
