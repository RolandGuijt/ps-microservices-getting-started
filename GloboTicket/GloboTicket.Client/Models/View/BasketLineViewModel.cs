using System;

namespace GloboTicket.Web.Models.View
{
    public class BasketLineViewModel
    {
        public Guid LineId { get; set; }
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public DateTimeOffset Date { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
