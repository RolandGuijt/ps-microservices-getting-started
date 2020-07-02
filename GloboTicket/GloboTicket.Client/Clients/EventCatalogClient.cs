using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GloboTicket.Client.Extensions;
using GloboTicket.Client.Models.Api;

namespace GloboTicket.Client.Clients
{
    public class EventCatalogClient: IEventCatalogClient
    {
        private readonly HttpClient client;

        public EventCatalogClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            var response = await client.GetAsync("/api/events");
            return await response.ReadContentAs<List<Event>>();
        }
    }
}
