using Pulsati.Core.Domain.Services.Validacao.Command;
using Ioutility.Franquias.Domain.Franquias.Models;

namespace Ioutility.Franquias.Domain.Franquias.Models.Validacoes
{
    public class FranquiaAcessoVOValidarModelCommand : BaseObjectValidacaoCommand<FranquiaAcessoVO> {

        public FranquiaAcessoVOValidarModelCommand(FranquiaAcessoVO entity) : base(entity) {

        }
        // Esperando confirmação sobre a variável Senha
        public override void PreencherRegrasValidacao() {
            ValidarCampoObrigatorio(entity => entity.FranquiaStatus, "Status");
        }
    }

}
