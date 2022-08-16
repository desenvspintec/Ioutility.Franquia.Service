using Pulsati.Core.Domain.DomainNotifications;

namespace Pulsati.Core.Api.ViewModels
{
    public class RespostaErroDeNotificacaoViewModel
    {
        public bool success { get; set; }
        public IEnumerable<string> errors { get; set; }
        public IEnumerable<Notification> errorsDetails { get; set; }
        
    }
}