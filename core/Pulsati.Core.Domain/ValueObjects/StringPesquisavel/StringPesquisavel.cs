using Pulsati.Core.Domain.Helpers.Extensions;
using Pulsati.Core.Domain.Interfaces;
using Pulsati.Core.Domain.Interfaces.Validacoes;

namespace Pulsati.Core.Domain.ValueObjects.StringPesquisavel
{
    public class StringPesquisavel : IValueObject<StringPesquisavel>
    {
        protected StringPesquisavel() { }
        public StringPesquisavel(string valor)
        {
            Valor = valor;
            ValorQuery = valor.FormatarParaBusca();

        }

        public string Valor { get; private set; }
        public string ValorQuery { get; private set; }
        public string DisplayNameTypeOf()
        {
            return "Texto pesquisavel";
        }

        public IEnumerable<IValidadorDomainCommand<StringPesquisavel>> ObterDomainValidadorCommands()
        {
            return new List<IValidadorDomainCommand<StringPesquisavel>>() { new StringPesquisavelValidacaoCommand(this)};
        }

        public override string ToString()
        {
            return Valor;
        }
    }
}
