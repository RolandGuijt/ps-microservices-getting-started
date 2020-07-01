using System;
using System.Threading.Tasks;
using GloboTicket.ShoppingBasketService;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Client.Controllers
{
    public class ShoppingBasketController : Controller
    {
        private readonly IShoppingBasketClient client;

        public ShoppingBasketController(IShoppingBasketClient client)
        {
            this.client = client;
        }

        public Task<IActionResult> Index()
        {
            return null;
        }

        //public async Task<IActionResult> AddToCart(Guid eventId)
        //{
        //}
    }
}
