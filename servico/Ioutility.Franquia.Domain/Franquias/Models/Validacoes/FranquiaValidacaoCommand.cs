using Ioutility.Franquias.Domain.Franquias.Models;
using Pulsati.Core.Domain.Constantes;
using Pulsati.Core.Domain.Enums;
using Pulsati.Core.Domain.Services.Validacao.Command;
using Pulsati.Core.Domain.Services.Validacao.DTOs;
using Ioutility.Franquias.Domain.Franquias.Models;

public class FranquiaValidacaoCommand : BaseEntityValidacaoCommand<Franquia> {
    public FranquiaValidacaoCommand(Franquia entity) : base(entity) {
    }

    public override void PreencherRegrasValidacao() {
        const string displayEmail = "E-mail";
        /*ValidarEmail(entity => entity.Email.Valor, displayEmail);
        ValidarCampoObrigatorio(entity => entity.Email.Valor, displayEmail);
        ValidarCampoTamanhoMaximo(entity => entity.Email.Valor, displayEmail, Constante.MAX_LEN_PADRAO);
        */
        const string displayCnpj = "CNPJ";
        ValidarCampoObrigatorio(entity => entity.Cnpj, displayCnpj);
        ValidarCampoTamanhoMaximo(entity => entity.Cnpj, displayCnpj, Constante.QUANTITADE_CARACTERIES_PARA_CNPJ);

        ValidarCampoObrigatorio(entity => entity.Telefone);
        ValidarCampoTamanhoMaximo(entity => entity.Telefone, "", Constante.QUANTITADE_CARACTERIES_PARA_TELEFONE);
        /*
        const string displayRazaoSocial = "Razão Social";
        ValidarCampoObrigatorio(entity => entity.RazaoSocial, displayRazaoSocial);
        ValidarCampoTamanhoMinimo(entity => entity.RazaoSocial.Valor, displayRazaoSocial, Constante.MIN_LEN_PADRAO);
        ValidarCampoTamanhoMaximo(entity => entity.RazaoSocial.Valor, displayRazaoSocial, Constante.MAX_LEN_PADRAO);
        */

        ValidarDocumento(entity => new ValidaroDocumentoDTO(ETipoDocumentoRegistroFederal.Cnpj, entity.Cnpj), "cnpj", "CNPJ");

        ValidarEntityDependente(entity => entity.DadosBancarios);
    }
}