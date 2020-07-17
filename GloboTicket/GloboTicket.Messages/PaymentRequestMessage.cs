using System;

namespace GloboTicket.Messages
{
    public class PaymentRequestMessage
    {
        public Guid BasketId { get; set; }
    }
}
