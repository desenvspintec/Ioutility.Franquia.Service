namespace Pulsati.Core.Domain.Bus.MessagesDTO.Email
{
    public class EnviarEmailCommand
    {
        public string Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Texto { get; set; }
    }
}
