using System;

namespace GloboTicket.Client.Models
{
    public class BasketLineViewModel
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
