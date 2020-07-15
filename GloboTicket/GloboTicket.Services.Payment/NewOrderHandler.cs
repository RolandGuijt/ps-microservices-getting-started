using System;
using System.Threading.Tasks;
using GloboTicket.Messages;
using Rebus.Handlers;

namespace GloboTicket.Services.Payment
{
    public class NewOrderHandler : IHandleMessages<NewOrderMessage>
    {
        public Task Handle(NewOrderMessage message)
        {
            Console.WriteLine($"New order received with {message.PriceTotal} total value");
            return Task.CompletedTask;
        }
    }
}
