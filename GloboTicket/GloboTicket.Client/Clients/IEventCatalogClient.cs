using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTicket.Client.Models.Api;

namespace GloboTicket.Client.Clients
{
    public interface IEventCatalogClient
    {
        Task<IEnumerable<Event>> GetAll();
    }
}
