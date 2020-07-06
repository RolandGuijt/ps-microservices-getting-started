using System;
using System.Threading.Tasks;
using GloboTicket.Client.Clients;
using GloboTicket.Client.Extensions;
using GloboTicket.Client.Models;
using GloboTicket.Client.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Client.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCatalogService eventCatalogService;
        private readonly IShoppingBasketService shoppingBasketService;
        private readonly Settings settings;

        public EventCatalogController(IEventCatalogService eventCatalogService, IShoppingBasketService shoppingBasketService, Settings settings)
        {
            this.eventCatalogService = eventCatalogService;
            this.shoppingBasketService = shoppingBasketService;
            this.settings = settings;
        }

        public async Task<IActionResult> Index()
        {
            var currentBasketId = Request.Cookies.GetCurrentBasketId(settings);
            var currentBasket = await shoppingBasketService.GetBasket(currentBasketId);
            var numberOfItems = currentBasket == null ? 0 : currentBasket.NumberOfItems;
            var events = await eventCatalogService.GetAll();
            return View(new EventListModel { Events = events, NumberOfItems = numberOfItems });
        }

        public async Task<IActionResult> Detail(Guid eventId)
        {
            var ev = await eventCatalogService.GetEvent(eventId);
            return View(ev);
        }
    }
}
