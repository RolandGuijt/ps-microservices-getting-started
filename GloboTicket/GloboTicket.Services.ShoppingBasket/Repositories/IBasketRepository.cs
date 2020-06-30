using GloboTicket.Services.ShoppingBasket.Entities;
using System;
using System.Threading.Tasks;

namespace GloboTicket.Services.ShoppingBasket.Repositories
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasketById(Guid basketId);

        void AddBasket(Basket basket);
    }
}