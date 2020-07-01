using System.Threading.Tasks;
using GloboTicket.EventCatalogService;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Client.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCatalogClient client;

        public EventCatalogController(IEventCatalogClient client)
        {
            this.client = client;
        }

        public async Task<IActionResult> Index()
        {
            var events = await client.GetAllEventsAsync();
            return View(events);
        }
    }
}
