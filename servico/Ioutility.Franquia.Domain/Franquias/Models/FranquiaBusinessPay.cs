using Pulsati.Core.Domain.Enums;
using Pulsati.Core.Domain.Interfaces;
using Pulsati.Core.Domain.Interfaces.Validacoes;
using Pulsati.Core.Domain.Models;

namespace Ioutility.Franquias.Domain.Franquias.Models
{
    public class FranquiaBusinessPay : IValueObject<FranquiaBusinessPay>
    {
        // EF CORE
        protected FranquiaBusinessPay()
        {}
        public FranquiaBusinessPay(string nrVendasMes, string configuracaoCartao)
        {
            NrVendasMes = nrVendasMes;
            ConfiguracaoCartao = configuracaoCartao;
        }    

        public string NrVendasMes { get; private set; }
        public string ConfiguracaoCartao { get; private set; }

        public string DisplayNameTypeOf() => "Business Pay";

        public IEnumerable<IValidadorDomainCommand<FranquiaBusinessPay>> ObterDomainValidadorCommands()
        {
            return new List<IValidadorDomainCommand<FranquiaBusinessPay>>();
        }

    }
}