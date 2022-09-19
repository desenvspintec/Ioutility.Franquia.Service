using Pulsati.Core.Domain.Services.Validacao.Command;

namespace Pulsati.Core.Domain.ValueObjects.StringPesquisavel
{
    public class StringPesquisavelValidacaoCommand : BaseObjectValidacaoCommand<StringPesquisavel>
    {
        public StringPesquisavelValidacaoCommand(StringPesquisavel entity) : base(entity)
        {
        }

        public override void PreencherRegrasValidacao()
        {
            ValidarCampoObrigatorio(entity => entity.Valor);
        }
    }
}
