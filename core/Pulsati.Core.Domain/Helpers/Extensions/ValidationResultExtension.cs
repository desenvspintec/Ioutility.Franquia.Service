using FluentValidation.Results;
using Pulsati.Core.Domain.Constantes;
using Pulsati.Core.Domain.DomainNotifications;

namespace Pulsati.Core.Domain.Helpers.Extensions
{
    public static class ValidationResultExtension
    {
        public static void AddErrors(this IList<ValidationFailure> erros, IList<ValidationFailure> errosConcat)
        {
            foreach (var erro in errosConcat)
            {
                erros.Add(erro);
            }
        }

        public static IList<Notification> ToNotification(this IList<ValidationFailure> erros)
        {
            var notificacoes = new List<Notification>();
            foreach (var erro in erros)
            {
                notificacoes.Add(new Notification(Constante.ERRO_AO_VALIDAR_NA_ENTIDADE_DE_DOMINIO, erro.ErrorMessage));
            }

            return notificacoes;
        }
    }
}
