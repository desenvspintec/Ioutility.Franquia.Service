using Pulsati.Core.Domain.Enums;
using Pulsati.Core.Domain.Interfaces;
using Pulsati.Core.Domain.Interfaces.Validacoes;
using Pulsati.Core.Domain.Models;

namespace Ioutility.Franquias.Domain.Franquias.Models
{
    public class FranquiaDadoBancario : IValueObject<FranquiaDadoBancario>
    {
        // EF CORE
        protected FranquiaDadoBancario()
        {}
        public FranquiaDadoBancario(string bancoId, string agencia, string conta, ETipoChavePix tipoChavePix, string chavePix)
        {
            BancoId = bancoId;
            Agencia = agencia;
            Conta = conta;
            TipoChavePix = tipoChavePix;
            ChavePix = chavePix;
        
        }    

        public string BancoId { get; private set; }
        public string Agencia { get; private set; }
        public string Conta { get; private set; }
        public ETipoChavePix TipoChavePix { get; private set; }
        public string ChavePix { get; private set; }

        public string DisplayNameTypeOf() => "Dados Bancarios";

        public IEnumerable<IValidadorDomainCommand<FranquiaDadoBancario>> ObterDomainValidadorCommands()
        {
            return new List<IValidadorDomainCommand<FranquiaDadoBancario>>();
        }
        public static string ObterTipoChavePixTxt(ETipoChavePix tipoChavePix)
        {
            switch (tipoChavePix)
            {
                case ETipoChavePix.Cpf:
                    return "CPF";
                case ETipoChavePix.Cnpj:
                    return "CNPJ";
                case ETipoChavePix.Telefone:
                    return "Telefone";
                default:
                    return $"Tipo de chave {tipoChavePix} não definido";
            }
        }
    }
}