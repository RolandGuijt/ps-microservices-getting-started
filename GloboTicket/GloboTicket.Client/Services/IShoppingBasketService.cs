using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTicket.Client.Models.Api;

namespace GloboTicket.Client.Services
{
    public interface IShoppingBasketService
    {
        Task<BasketLine> AddToBasket(Guid basketId, BasketLineForCreation basketLine);
        Task<IEnumerable<BasketLine>> GetLinesForBasket(Guid basketId);
        Task<Basket> GetBasket(Guid basketId);
        Task UpdateLine(Guid basketId, BasketLineForUpdate basketLineForUpdate);
        Task RemoveLine(Guid basketId, Guid lineId);
    }
}
