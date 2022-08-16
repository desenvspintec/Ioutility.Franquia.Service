using Microsoft.EntityFrameworkCore;
using Pulsati.Core.Domain.EventSources;
using Pulsati.Core.Domain.Interfaces.Repositorys;

namespace Pulsati.Core.Repositorys
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly DbSet<EventSource> _dbSet;
        public EventStoreRepository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<EventSource>();
        }

        public async Task AddEvent(EventSource evento)
        {
            try
            {
                await _dbSet.AddAsync(evento);

            }
            catch (Exception exception)
            {
                throw new Exception("Não foi possivel salvar o log do evento (addevent)", exception);
            }
        }
    }
}
