using System;

namespace GloboTicket.Services.ShoppingBasket.Models
{
    public class BasketLineForCreation
    { 
        public Guid EventId { get; set; }
        public int TicketAmount { get; set; }
    }
}
