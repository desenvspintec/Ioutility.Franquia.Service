using Ioutility.Franquias.Domain.Franquias.DTOs;
using Pulsati.Core.Domain.Services.Validacao.Command;

namespace Ioutility.Franquias.Domain.Franquias.Models.Validacoes
{
    internal class FranquiaDadosBancariosValidacaoCommand : BaseObjectValidacaoCommand<DadosBancariosVODTO> {
        public FranquiaDadosBancariosValidacaoCommand(DadosBancariosVODTO entity) : base(entity) {
        }

        public override void PreencherRegrasValidacao() {
            ValidarCampoObrigatorio(entity => entity.BancoId, "Banco");
            ValidarCampoObrigatorio(entity => entity.Agencia);
            ValidarCampoObrigatorio(entity => entity.Conta);
            ValidarCampoObrigatorio(entity => entity.ChavePix, "Chave Pix");
        }
    }
}
