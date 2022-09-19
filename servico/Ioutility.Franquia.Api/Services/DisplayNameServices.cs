using Ioutility.Franquias.Domain.Franquias.Models;
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


        };
        }
    }
}
