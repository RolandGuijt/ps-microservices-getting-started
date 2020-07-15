using System;

namespace GloboTicket.Messages
{
    public class NewOrderMessage
    {
        public Guid UserId { get; set; }
        public int PriceTotal { get; set; }
    }
}
