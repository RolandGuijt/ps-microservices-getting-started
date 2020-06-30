using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTicket.EventCatalogService;

namespace GloboTicket.Client.Repositories
{
    public interface IEventCatalogRepository
    {
        Task<IEnumerable<Event>> GetAll();
    }
}
