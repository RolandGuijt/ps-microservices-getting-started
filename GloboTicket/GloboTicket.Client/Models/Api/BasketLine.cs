using System;

namespace GloboTicket.Client.Models.Api
{
    public class BasketLine
    {
        public Guid BasketLineId { get; set; }
        public Guid BasketId { get; set; }
        public Guid EventId { get; set; }
        public int TicketAmount { get; set; }
        public int Price { get; set; }
        public Event Event { get; set; }
    }
}
