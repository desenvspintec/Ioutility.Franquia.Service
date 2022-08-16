using Pulsati.Core.Domain.EventSources;

namespace Pulsati.Core.Domain.Interfaces.Repositorys
{
    public interface IEventStoreRepository
    {
        Task AddEvent(EventSource evento);
    }
}
