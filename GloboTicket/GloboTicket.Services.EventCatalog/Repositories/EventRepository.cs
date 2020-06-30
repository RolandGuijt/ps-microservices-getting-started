using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloboTicket.Services.EventCatalog.DbContexts;
using GloboTicket.Services.EventCatalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.Services.EventCatalog.Repositories
{
    public class EventRepository: IEventRepository
    {
        private readonly EventCatalogDbContext _eventCatalogDbContext;

        public EventRepository(EventCatalogDbContext eventCatalogDbContext)
        {
            _eventCatalogDbContext = eventCatalogDbContext;
        }


        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _eventCatalogDbContext.Events.ToListAsync();

        }

        public async Task<Event> GetEventByiId(string eventId)
        {
            return await _eventCatalogDbContext.Events.Where(x => x.CategoryId.ToString() == eventId).FirstOrDefaultAsync();
        }
    }

}
