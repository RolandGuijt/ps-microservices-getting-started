using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTicket.Client.Models.Api;

namespace GloboTicket.Client.Clients
{
    public interface IShoppingBasketService
    {
        Task<BasketLine> AddToBasket(Guid basketId, Guid userId, Guid eventId, int amount);
        Task<IEnumerable<BasketLine>> GetLinesForBasket(Guid basketId);
        Task<Basket> GetBasket(Guid basketId);
    }
}
