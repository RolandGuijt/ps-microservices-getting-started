using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GloboTicket.Client.Extensions;
using GloboTicket.Client.Models.Api;

namespace GloboTicket.Client.Services
{
    public class ShoppingBasketService: IShoppingBasketService
    {
        private readonly HttpClient client;

        public ShoppingBasketService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<BasketLine> AddToBasket(Guid basketId, Guid userId, Guid eventId, int amount)
        {
            if (basketId == Guid.Empty)
            {
                var basketResponse = await client.PostAsJson("/api/baskets", new BasketForCreation { UserId = userId });
                var basket = await basketResponse.ReadContentAs<Basket>();
                basketId = basket.BasketId;
            }

            var response = await client.PostAsJson($"api/baskets/{basketId}/basketlines", new BasketLineForCreation { EventId = eventId, TicketAmount = amount });
            return await response.ReadContentAs<BasketLine>();
        }

        public async Task<Basket> GetBasket(Guid basketId)
        {
            if (basketId == Guid.Empty)
                return null;
            var response = await client.GetAsync($"/api/baskets/{basketId}");
            return await response.ReadContentAs<Basket>();
        }

        public async Task<IEnumerable<BasketLine>> GetLinesForBasket(Guid basketId)
        {
            if (basketId == Guid.Empty)
                return new BasketLine[0];
            var response = await client.GetAsync($"/api/baskets/{basketId}/basketLines");
            return await response.ReadContentAs<BasketLine[]>();

        }

        public async Task UpdateLine(Guid basketId, Guid lineId, int quantity)
        {
            await client.PutAsJson($"/api/baskets/{basketId}/basketLines/{lineId}", 
                new BasketLineForUpdate { TicketAmount = quantity });
        }

        public async Task RemoveLine(Guid basketId, Guid lineId)
        {
            await client.DeleteAsync($"/api/baskets/{basketId}/basketLines/{lineId}");
        }
    }
}
