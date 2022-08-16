namespace Pulsati.Core.Domain.DomainNotifications
{
    public class DomainNotification
    {
        private readonly List<Notification> _notifications;

        public DomainNotification()
        {
            _notifications = new List<Notification>();
        }

        public void Add(string tipo, string nome)
        {
            var notification = new Notification(tipo, nome);
            _notifications.Add(notification);
        }

        public void AddRange(IEnumerable<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public List<Notification> Obter()
        {
            return _notifications.ToList();
        }
        public bool HaNotificacao() => _notifications.Any();
    }
}
