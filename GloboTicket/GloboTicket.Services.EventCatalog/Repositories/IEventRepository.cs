using System;
using GloboTicket.Services.EventCatalog.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.Services.EventCatalog.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetEventById(Guid eventId);
        Task<IEnumerable<Event>> GetEventsForCategory(Guid categoryId);
    }
}
