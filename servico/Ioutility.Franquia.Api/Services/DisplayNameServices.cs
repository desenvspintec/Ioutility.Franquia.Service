using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Domain.Procedimentos.DTOs;
using Ioutility.Franquias.Domain.Procedimentos.Models;
using Pulsati.Core.Domain.DisplayNames;
using Pulsati.Core.Domain.Interfaces;
using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.ValueObjects.Enderecos;

namespace Ioutility.Franquias.Api.Services
{
    public class DisplayNameServices : IDisplayNameService
    {
        public DisplayName? ObterPorNomePropriedade(string nomePropriedade) => ObterTodos().FirstOrDefault(dn => dn.NomePropriedade == nomePropriedade);

        public IReadOnlyCollection<DisplayName> ObterTodos()
        {
            return new List<DisplayName>()
            {
                new DisplayName(nameof(IEntityBasic.Id), "Id"),
                new DisplayName(nameof(IEntityBasic.Nome), "Nome"),

                new DisplayName(nameof(Franquia.Endereco), "Endereço"),
                new DisplayName(nameof(Franquia.DadosBancarios), "Dados Bancarios"),

                new DisplayName(nameof(FranquiaDadoBancario.BancoId), "Banco"),
                new DisplayName(nameof(FranquiaDadoBancario.Agencia), "Agencia"),
                new DisplayName(nameof(FranquiaDadoBancario.Conta), "Conta"),
                new DisplayName(nameof(FranquiaDadoBancario.ChavePix), "Chave Pix"),
                new DisplayName(nameof(FranquiaDadoBancario.TipoChavePix), "Tipo de chave pix"),

                new DisplayName(nameof(EnderecoVO.Cep), "CEP"),
                new DisplayName(nameof(EnderecoVO.Bairro), "Bairro"),
                new DisplayName(nameof(EnderecoVO.Estado), "Estado"),
                new DisplayName(nameof(EnderecoVO.Numero), "Número"),

                new DisplayName(nameof(Procedimento.TipoProcedimentoId), "Tipo do procedimento"),
                new DisplayName(nameof(Procedimento.Especialidade), "Especialidade"),
                new DisplayName(nameof(ProcedimentoDTO.ValorSugerido), "Valor Sugerido"),
                new DisplayName(nameof(ProcedimentoDTO.ValorMinimo), "Valor Mínimo"),
                new DisplayName(nameof(ProcedimentoDTO.ValorMaximo), "Valor Máximo"),
                new DisplayName(nameof(ProcedimentoDTO.ValorCustoAdicional), "Custos Adicionais"),
                new DisplayName(nameof(ProcedimentoDTO.ComissaoValor), "Valor da comissão"),
                new DisplayName(nameof(ProcedimentoDTO.ComissaoTipo), "Tipo da comissão"),

                new DisplayName(nameof(ProcedimentoListagemViewModel.ProcedimentoStatus), "Status"),
                new DisplayName(nameof(ProcedimentoListagemViewModel.TipoProcedimento), "Tipo do procedimento"),
                new DisplayName(nameof(ProcedimentoListagemViewModel.CodProcedimento), "Cod. procedimento"),

        };
        }
    }
}
