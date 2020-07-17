using System;
using System.Threading.Tasks;
using GloboTicket.Messages;
using Rebus.Handlers;

namespace GloboTicket.Services.Payment
{
    public class NewOrderHandler : IHandleMessages<PaymentRequestMessage>
    {
        public Task Handle(PaymentRequestMessage message)
        {
            Console.WriteLine($"Payment request received for basket id {message.BasketId}.");
            return Task.CompletedTask;
        }
    }
}
