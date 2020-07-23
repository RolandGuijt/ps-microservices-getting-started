using System;
using System.Threading.Tasks;
using GloboTicket.Grpc;
using GloboTicket.Web.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Web.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly Events.EventsClient eventCatalogService;

        public EventCatalogController(Events.EventsClient eventCatalogService)
        {
            this.eventCatalogService = eventCatalogService;
        }

        public async Task<IActionResult> Index(Guid categoryId)
        {
            var getCategories = eventCatalogService.GetAllCategoriesAsync(new GetAllCategoriesRequest());
            var getEvents = categoryId == Guid.Empty ? eventCatalogService.GetAllAsync(new GetAllEventsRequest()) :
                eventCatalogService.GetAllByCategoryIdAsync(new GetAllEventsByCategoryIdRequest { CategoryId = categoryId.ToString() });
            await Task.WhenAll(new Task[] { getCategories.ResponseAsync, getEvents.ResponseAsync });

            return View(
                new EventListModel
                {
                    Events = getEvents.ResponseAsync.Result.Events,
                    Categories = getCategories.ResponseAsync.Result.Categories,
                    SelectedCategory = categoryId
                }
            );
        }

        [HttpPost]
        public IActionResult SelectCategory([FromForm]Guid selectedCategory)
        {
            return RedirectToAction("Index", new { categoryId = selectedCategory });
        }

        public async Task<IActionResult> Detail(Guid eventId)
        {
            var ev = await eventCatalogService.GetByEventIdAsync(new GetByEventIdRequest { EventId = eventId.ToString() });
            return View(ev.Event);
        }
    }
}
