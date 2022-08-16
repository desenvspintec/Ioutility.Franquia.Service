using Pulsati.Core.Domain.Enums;
using Pulsati.Core.Domain.Models;

namespace Pulsati.Core.Domain.EventSources
{
    public class EventSource : Entity<EventSource>
    {
        protected EventSource() { }
        public EventSource(Guid id, Guid entityReferenteId, string nomeEvent, string displayNameDaEntityReferente, string jsonDados, ETipoOperacaoCrud tipoOperacaoCrud): base (id)
        {
            EntityReferenteId = entityReferenteId;
            DisplayNameDaEntityReferente = displayNameDaEntityReferente;
            JsonDados = jsonDados;
            TipoOperacaoCrud = tipoOperacaoCrud;
            NomeEvent = nomeEvent;
        }
        public Guid EntityReferenteId { get; private set; }
        public string DisplayNameDaEntityReferente { get; private set; }
        public string JsonDados { get; private set; }
        public string NomeEvent { get; private set; }
        public ETipoOperacaoCrud TipoOperacaoCrud { get; private set; }

        public override string DisplayNameTypeOf() => "Event Source";
    }
}
