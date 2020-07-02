using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GloboTicket.Client.Clients
{
    public class ShoppingBasketClient: IShoppingBasketClient
    {
        private readonly HttpClient client;

        public ShoppingBasketClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task AddToBasket(Guid eventId)
        {

        }
    }
}
