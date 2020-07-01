using GloboTicket.Services.EventCatalog.DbContexts;
using GloboTicket.Services.EventCatalog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.Services.EventCatalog.Repositories
{
    public class EventRepository: IEventRepository
    {
        private readonly EventCatalogDbContext _eventCatalogDbContext;

        public EventRepository(EventCatalogDbContext eventCatalogDbContext)
        {
            _eventCatalogDbContext = eventCatalogDbContext;
        }


        public async Task<IEnumerable<Event>> GetEvents(Guid categoryId)
        {
            if(categoryId == Guid.Empty)
                  return await _eventCatalogDbContext.Events.Include(x => x.Category).ToListAsync();
            return await _eventCatalogDbContext.Events.Include(x => x.Category).Where(x => x.CategoryId == categoryId).ToListAsync();
        }

        public async Task<Event> GetEventById(Guid eventId)
        {
            return await _eventCatalogDbContext.Events.Include(x => x.Category).Where(x => x.EventId == eventId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsByIds(Guid[] eventIds)
        {
            return await _eventCatalogDbContext.Events.Include(x => x.Category).Where(x => eventIds.Contains(x.EventId)).ToListAsync();
        }
    }
}
