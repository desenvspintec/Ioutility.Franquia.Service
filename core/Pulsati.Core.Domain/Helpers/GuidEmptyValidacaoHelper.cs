using FluentValidation;

namespace Pulsati.Core.Domain.Helpers
{
    public class GuidEmptyValidacaoHelper : AbstractValidator<Guid?>
    {
        public GuidEmptyValidacaoHelper(string propriedade)
        {

            var guidVazio = Guid.Empty;
            RuleFor(guid => guid).Must(guid => !(guid == guidVazio || guid == null))
                .WithMessage(MensagemErroHelper.NaoNulo(propriedade));
        }
    }
}
