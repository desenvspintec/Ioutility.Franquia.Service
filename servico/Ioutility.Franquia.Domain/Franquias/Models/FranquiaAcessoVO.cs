using Pulsati.Core.Domain.Interfaces;
using Pulsati.Core.Domain.Interfaces.Validacoes;
using Ioutility.Franquias.Domain.Franquias.Enums;
using Ioutility.Franquias.Domain.Franquias.Models.Validacoes;

namespace Ioutility.Franquias.Domain.Franquias.Models
{
    public class FranquiaAcessoVO : IValueObject<FranquiaAcessoVO> {
        public FranquiaAcessoVO(EFranquiaStatus franquiaStatus) {
            FranquiaStatus = franquiaStatus;
        }

        public EFranquiaStatus FranquiaStatus { get; private set; }

        public string DisplayNameTypeOf() => "Informações de status da Franquia";

        public IEnumerable<IValidadorDomainCommand<FranquiaAcessoVO>> ObterDomainValidadorCommands() {
            return new List<IValidadorDomainCommand<FranquiaAcessoVO>>() {
                new FranquiaAcessoVOValidarModelCommand(this)
            };
        }
        public static string ObterStatusTxt(EFranquiaStatus status) {
            switch (status) {
                case EFranquiaStatus.Ativo:
                    return "Ativo";
                case EFranquiaStatus.Inativo:
                    return "Inativo";
                default:
                    return $"Status {status} não definido";
            }
        }
        public void SetStatus(EFranquiaStatus franquiaStatus) {
            FranquiaStatus = franquiaStatus;
        }
    }
}
