using GloboTicket.Services.ShoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.Services.ShoppingBasket.Repositories
{
    public interface IBasketLinesRepository
    {
        Task<IEnumerable<BasketLine>> GetBasketLines(Guid basketId);

        Task<BasketLine> GetBasketLineById(Guid basketLineId);

        void AddBasketLine(BasketLine basketLine);

        void UpdateBasketLine(BasketLine basketLine);

        void RemoveBasketLine(BasketLine basketLine);

        void SaveChanges();
    }
}