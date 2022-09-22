using Pulsati.Core.Domain.Enums;
using Pulsati.Core.Domain.Interfaces;
using Pulsati.Core.Domain.Interfaces.Validacoes;
using Pulsati.Core.Domain.Models;

namespace Ioutility.Franquias.Domain.Franquias.Models
{
    public class BusinessPayVO : IValueObject<BusinessPayVO>
    {
        // EF CORE
        protected BusinessPayVO()
        {}
        public BusinessPayVO(string nrVendasMes, string configuracaoCartao)
        {
            NrVendasMes = nrVendasMes;
            ConfiguracaoCartao = configuracaoCartao;
        }    

        public string NrVendasMes { get; private set; }
        public string ConfiguracaoCartao { get; private set; }

        public string DisplayNameTypeOf() => "Business Pay";

        public IEnumerable<IValidadorDomainCommand<BusinessPayVO>> ObterDomainValidadorCommands()
        {
            return new List<IValidadorDomainCommand<BusinessPayVO>>();
        }

    }
}