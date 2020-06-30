using GloboTicket.Services.ShoppingBasket.DbContexts;
using GloboTicket.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.Services.ShoppingBasket.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ShoppingBasketDbContext _shoppingBasketDbContext;

        public BasketRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
            _shoppingBasketDbContext = shoppingBasketDbContext;
        }         

        public async Task<Basket> GetBasketById(Guid basketId)
        {
            return await _shoppingBasketDbContext.Baskets
                .Where(b => b.BasketId == basketId).FirstOrDefaultAsync();
        }

        public void AddBasket(Basket basket)
        {
            _shoppingBasketDbContext.Baskets.Add(basket);
        }

        public async void SaveChanges()
        {
            await _shoppingBasketDbContext.SaveChangesAsync();
        }
    }
}
