using System.Threading.Tasks;
using GloboTicket.Client.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Client.Controllers
{
    public class ShoppingBasketController: Controller
    {
        private readonly IShoppingBasketRepository shoppingBasketRepository;

        public ShoppingBasketController(IShoppingBasketRepository shoppingBasketRepository)
        {
            this.shoppingBasketRepository = shoppingBasketRepository;
        }

        public Task<IActionResult> Index()
        {
            return null;
        }
    }
}
