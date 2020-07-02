using System;
using System.Threading.Tasks;
using GloboTicket.Client.Clients;
using GloboTicket.Client.Extensions;
using GloboTicket.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Client.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCatalogClient eventCatalogClient;
        private readonly IShoppingBasketClient shoppingBasketClient;
        private readonly Settings settings;

        public EventCatalogController(IEventCatalogClient eventCatalogClient, IShoppingBasketClient shoppingBasketClient, Settings settings)
        {
            this.eventCatalogClient = eventCatalogClient;
            this.shoppingBasketClient = shoppingBasketClient;
            this.settings = settings;
        }

        public async Task<IActionResult> Index()
        {
            var currentBasketId = Request.Cookies.GetCurrentBasketId(settings);
            var currentBasket = await shoppingBasketClient.GetBasket(currentBasketId);
            ViewBag.NumberOfBasketItems = currentBasket == null ? 0 : currentBasket.NumberOfLines;
            var events = await eventCatalogClient.GetAll();
            return View(events);
        }
    }
}
