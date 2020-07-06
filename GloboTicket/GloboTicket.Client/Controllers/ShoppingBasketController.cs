using System;
using System.Linq;
using System.Threading.Tasks;
using GloboTicket.Client.Clients;
using GloboTicket.Client.Extensions;
using GloboTicket.Client.Models;
using GloboTicket.Client.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Client.Controllers
{
    public class ShoppingBasketController : Controller
    {
        private readonly IShoppingBasketService basketClient;
        private readonly IEventCatalogService catalogClient;
        private readonly Settings settings;

        public ShoppingBasketController(IShoppingBasketService basketClient, IEventCatalogService catalogClient, Settings settings)
        {
            this.basketClient = basketClient;
            this.catalogClient = catalogClient;
            this.settings = settings;
        }

        public async Task<IActionResult> Index()
        {
            var basketLines = await basketClient.GetLinesForBasket(Request.Cookies.GetCurrentBasketId(settings));
            var eventIds = basketLines.Select(bl => bl.EventId);
            var eventsInBasket = await catalogClient.GetByEventIds(eventIds);
            var lineViewModels = basketLines.Select(bl =>
            {
                var currentEvent = eventsInBasket.Single(e => e.EventId == bl.EventId);
                return new BasketLineViewModel
                {
                    EventId = bl.EventId,
                    EventName = currentEvent.Name,
                    Date = currentEvent.Date,
                    Price = currentEvent.Price,
                    Quantity = bl.TicketAmount
                };
            });
            return View(lineViewModels);
        }

        public async Task<IActionResult> AddToBasket(Guid eventId, int numberOfTickets)
        {
            var basketId = Request.Cookies.GetCurrentBasketId(settings);
            var basketLine = await basketClient.AddToBasket(basketId, settings.UserId, eventId, numberOfTickets);
            Response.Cookies.Append(settings.BasketIdCookieName, basketLine.BasketId.ToString());

            return RedirectToAction("Index");
        }
    }
}
