using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTicket.EventCatalogService;

namespace GloboTicket.Client.Repositories
{
    public class EventCatalogRepository: IEventCatalogRepository
    {
        private readonly IEventCatalogClient client;

        public EventCatalogRepository(IEventCatalogClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await client.EventsAllAsync(null);
        }
    }
}
