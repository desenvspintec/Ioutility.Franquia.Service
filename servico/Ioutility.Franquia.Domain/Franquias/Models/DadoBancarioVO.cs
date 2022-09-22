using Pulsati.Core.Domain.Enums;
using Pulsati.Core.Domain.Enums.EnumText;
using Pulsati.Core.Domain.Interfaces;
using Pulsati.Core.Domain.Interfaces.Validacoes;
using Pulsati.Core.Domain.Models;

namespace Ioutility.Franquias.Domain.Franquias.Models
{
    public class DadoBancarioVO : IValueObject<DadoBancarioVO>
    {
        // EF CORE
        protected DadoBancarioVO()
        {}
        public DadoBancarioVO(string bancoId, string agencia, string conta, ETipoChavePix tipoChavePix, string tipoChavePixTxt, string chavePix)
        {
            BancoId = bancoId;
            Agencia = agencia;
            Conta = conta;
            TipoChavePix = tipoChavePix;
            TipoChavePixTxt = tipoChavePixTxt;
            ChavePix = chavePix;

            }    

        public string BancoId { get; private set; }
        public string Agencia { get; private set; }
        public string Conta { get; private set; }
        public ETipoChavePix TipoChavePix { get; private set; }
        public string TipoChavePixTxt { get; private set; }
        public string ChavePix { get; private set; }


        public string DisplayNameTypeOf() => "Dados Bancarios";

        public IEnumerable<IValidadorDomainCommand<DadoBancarioVO>> ObterDomainValidadorCommands()
        {
            return new List<IValidadorDomainCommand<DadoBancarioVO>>();
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