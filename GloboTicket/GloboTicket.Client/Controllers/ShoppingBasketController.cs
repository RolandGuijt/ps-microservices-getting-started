using System;
using System.Collections.Generic;
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
        private readonly IShoppingBasketService basketService;
        private readonly IEventCatalogService catalogService;
        private readonly Settings settings;

        public ShoppingBasketController(IShoppingBasketService basketService, IEventCatalogService catalogService, Settings settings)
        {
            this.basketService = basketService;
            this.catalogService = catalogService;
            this.settings = settings;
        }

        public async Task<IActionResult> Index()
        {
            var basketLines = await basketService.GetLinesForBasket(Request.Cookies.GetCurrentBasketId(settings));
            var eventIds = basketLines.Select(bl => bl.EventId);
            var eventsInBasket = await catalogService.GetByEventIds(eventIds);
            var lineViewModels = basketLines.Select(bl =>
            {
                var currentEvent = eventsInBasket.Single(e => e.EventId == bl.EventId);
                return new BasketLineViewModel
                {
                    LineId = bl.BasketLineId,
                    EventId = bl.EventId,
                    EventName = currentEvent.Name,
                    Date = currentEvent.Date,
                    Price = currentEvent.Price,
                    Quantity = bl.TicketAmount
                };
            });
            return View(lineViewModels);
        }

        public async Task<IActionResult> AddLine(Guid eventId, int numberOfTickets)
        {
            var basketId = Request.Cookies.GetCurrentBasketId(settings);
            var basketLine = await basketService.AddToBasket(basketId, settings.UserId, eventId, numberOfTickets);
            Response.Cookies.Append(settings.BasketIdCookieName, basketLine.BasketId.ToString());

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateLine(IEnumerable<BasketLineViewModel> basketLineUpdates)
        {
            if (basketLineUpdates == null || basketLineUpdates.Count() != 1)
                throw new ArgumentException("Error updating basket line: unexpected amount of updates");
            var basketId = Request.Cookies.GetCurrentBasketId(settings);
            await basketService.UpdateLine(basketId, basketLineUpdates.First().LineId, basketLineUpdates.First().Quantity);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveLine(Guid lineId)
        {
            var basketId = Request.Cookies.GetCurrentBasketId(settings);
            await basketService.RemoveLine(basketId, lineId);
            return RedirectToAction("Index");
        }
    }
}
