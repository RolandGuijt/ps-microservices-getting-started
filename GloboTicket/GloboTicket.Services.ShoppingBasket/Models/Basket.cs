using System;

namespace GloboTicket.Services.ShoppingBasket.Models
{
    public class Basket
    {        
        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
        public int NumberOfItems { get; set; }
    }
}
