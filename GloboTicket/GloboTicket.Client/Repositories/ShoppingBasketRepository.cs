using GloboTicket.ShoppingBasketService;

namespace GloboTicket.Client.Repositories
{
    public class ShoppingBasketRepository: IShoppingBasketRepository
    {
        private readonly IShoppingBasketClient shoppingBasketClient;

        public ShoppingBasketRepository(IShoppingBasketClient shoppingBasketClient)
        {
            this.shoppingBasketClient = shoppingBasketClient;
        }
    }
}
