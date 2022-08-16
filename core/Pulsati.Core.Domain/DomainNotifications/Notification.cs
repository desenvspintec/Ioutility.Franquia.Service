namespace Pulsati.Core.Domain.DomainNotifications
{
    public class Notification
    {
        public Notification(string tipo, string notificacao)
        {
            Tipo = tipo;
            Notificacao = notificacao;
        }

        public string Tipo { get; private set; }
        public string Notificacao { get; private set; }

        public string ObterDescricao() => $"{Tipo} - {Notificacao}";
    }
}
