using System;

namespace GloboTicket.Services.TicketCatalog.Domain
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Description { get; set; }
    }
}
