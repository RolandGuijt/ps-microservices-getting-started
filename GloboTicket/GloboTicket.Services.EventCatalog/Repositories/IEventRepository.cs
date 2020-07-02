using System;
using GloboTicket.Services.EventCatalog.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.Services.EventCatalog.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents(Guid categoryId, Guid[] eventIds);
        Task<Event> GetEventById(Guid eventId);
    }
}
