using Ioutility.Franquias.Domain.Franquias.DTOs;
using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Domain.Franquias.Enums;
using Pulsati.Core.Domain.Enums;
using Pulsati.Core.Domain.ValueObjects.Enderecos;
using System;
using Ioutility.Franquias.Domain.Procedimentos.DTOs;
using Ioutility.Franquias.Domain.Procedimentos.Enums;
using Ioutility.Franquias.Domain.Procedimentos.Models;
using Pulsati.Core.Domain.DTOs.ValueObjects;

namespace Ioutility.Franquias.Tests.Testes.Franquias
{
    public static class FranquiaTestsHelper
    {
        public static FranquiaDTO ObterDTOValido()
        {
            return new FranquiaDTO
            {
                Id = Guid.Empty,
                ImagemFranquia = "imagem.png",
                Nome = "TESTE NOME",
                Cnpj = "22324498000180",

                ResponsavelLegal = "RESPONSAVEL LEGAL",
                Email = "email@gmail.com",
                Telefone =  "61999999999",
                CelularWhatsApp = "61999999999",
                Endereco = _obterEndereco(),
                DadosBancarios = _obterDadosBancarios(),
                BusinessPay = _obterBusinessPay(),
                Acesso = _obterDadosAcesso(),
            };
        }

        private static DadosBancariosVODTO _obterDadosBancarios()
        {
            return new DadosBancariosVODTO
            {
                BancoId = "001",
                Agencia = "00000",
                Conta = "11111111",
                TipoChavePix = ETipoChavePix.Cnpj,
                ChavePix = "93197584686",
            };
        }

        private static EnderecoVODTO _obterEndereco()
        {
            return new EnderecoVODTO {
                Complemento = "Lado direito da rua",
                Numero = 1755,
                Logradouro = "Rua Alfredo",
                Bairro = "Margem direita",
                Cidade = "Joinville",
                Estado = "Santa Cataria",
                Uf = "SC",
                Cep = "89021001",
                Arquivos = "arquivo.jpg"
              };
        }

        private static BusinessPayVODTO _obterBusinessPay()
        {
            return new BusinessPayVODTO
            { 
                NrVendasMes = "1234",
                ConfiguracaoCartao = "D+1"
            };
        }

         private static FranquiaAcessoVODTO _obterDadosAcesso()
        {
            return new FranquiaAcessoVODTO
            {
                FranquiaStatus = EFranquiaStatus.Ativo
            };
        }

    }
}
