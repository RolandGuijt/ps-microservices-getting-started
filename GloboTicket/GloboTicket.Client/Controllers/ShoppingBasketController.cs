using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloboTicket.EventCatalogService;
using GloboTicket.ShoppingBasketService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Client.Controllers
{
    public class ShoppingBasketController : Controller
    {
        private readonly IShoppingBasketClient basketClient;
        private readonly IEventCatalogClient catalogClient;

        private const string BasketIdCookieName = "BasketId";
        private readonly Guid UserId = Guid.Parse("{E455A3DF-7FA5-47E0-8435-179B300D531F}");

        public ShoppingBasketController(IShoppingBasketClient basketClient, IEventCatalogClient catalogClient)
        {
            this.basketClient = basketClient;
            this.catalogClient = catalogClient;
        }

        public async Task<IActionResult> Index()
        {
            var basketLines = await basketClient.GetLinesForBasketAsync(GetCurrentBasketId());
            var eventIds = basketLines.Select(bl => bl.EventId).ToArray();
           // var eventsInBasket = await catalogClient.GetEventsByEventIdsAsync(eventIds);
            return View(basketLines);
        }

        public async Task<IActionResult> AddToBasket(Guid eventId)
        {
            Guid.TryParse(Request.Cookies[BasketIdCookieName], out Guid basketId);

            if (basketId == null)
            {
                var basket = await basketClient.NewBasketAsync(new BasketForCreation { UserId = UserId });
                basketId = basket.BasketId;
                Response.Cookies.Append(BasketIdCookieName, basket.BasketId.ToString());
            }

            await basketClient.NewBasketLineAsync(basketId, new BasketLineForCreation { EventId = eventId, TicketAmount = 1 });
            return RedirectToAction("Index");
        }

        private Guid GetCurrentBasketId()
        {
            Guid.TryParse(Request.Cookies[BasketIdCookieName], out Guid basketId);
            return basketId;
        }
    }
}
