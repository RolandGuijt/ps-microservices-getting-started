using System.Threading.Tasks;
using GloboTicket.Client.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Client.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCatalogRepository eventCatalogRepository;

        public EventCatalogController(IEventCatalogRepository eventCatalogRepository)
        {
            this.eventCatalogRepository = eventCatalogRepository;
        }

        public async Task<IActionResult> Index()
        {
            var events = await eventCatalogRepository.GetAll();
            return View(events);
        }
    }
}
