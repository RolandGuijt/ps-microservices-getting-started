using System;

namespace GloboTicket.Services.ShoppingBasket.Models
{
    public class BasketLine
    {
        public Guid BasketLineId { get; set; }
        public Guid EventId { get; set; }
        public int TicketAmount { get; set; }
    }
}
