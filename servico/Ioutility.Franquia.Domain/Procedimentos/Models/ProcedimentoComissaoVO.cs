using Ioutility.Franquias.Domain.Procedimentos.Validacoes;
using Pulsati.Core.Domain.Interfaces.Validacoes;

namespace Ioutility.Franquias.Domain.Procedimentos.Models
{
    public class ProcedimentoComissaoVO : IObjectComDomainValidacao<ProcedimentoComissaoVO>
    {
        public ProcedimentoComissaoVO(ETipoComissao tipo, double valor)
        {
            Tipo = tipo;
            Valor = valor;
        }

        public ETipoComissao Tipo { get; private set; }
        public double Valor { get; private set; }
        public IEnumerable<IValidadorDomainCommand<ProcedimentoComissaoVO>> ObterDomainValidadorCommands()
        {
            return new List<IValidadorDomainCommand<ProcedimentoComissaoVO>>() { new ProcedimentoComissaoVOValidacaoCommand(this) };
        }
    }
}