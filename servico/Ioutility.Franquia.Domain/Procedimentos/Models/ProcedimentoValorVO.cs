using Ioutility.Franquias.Domain.Procedimentos.Validacoes;
using Pulsati.Core.Domain.Interfaces.Validacoes;

namespace Ioutility.Franquias.Domain.Procedimentos.Models
{
    public class ProcedimentoValorVO : IObjectComDomainValidacao<ProcedimentoValorVO>
    {
        protected ProcedimentoValorVO()
        {

        }
        public ProcedimentoValorVO(double sugerido, double minimo, double maximo, double custoAdicional)
        {
            Sugerido = sugerido;
            Minimo = minimo;
            Maximo = maximo;
            CustoAdicional = custoAdicional;
        }

        public double Sugerido { get; private set; }
        public double Minimo { get; private set; }
        public double Maximo { get; private set; }
        public double CustoAdicional { get; private set; }
        public IEnumerable<IValidadorDomainCommand<ProcedimentoValorVO>> ObterDomainValidadorCommands()
        {
            return new List<IValidadorDomainCommand<ProcedimentoValorVO>> { new ProcedimentoValorVOValidacaoCommand(this) };
        }
    }
}