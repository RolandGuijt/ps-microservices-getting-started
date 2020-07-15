using System;
using Microsoft.Azure.Storage;
using Microsoft.Extensions.Configuration;
using Rebus.Activation;
using Rebus.Config;

namespace GloboTicket.Services.Payment
{
    public class Program
    {
        public static void Main()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var storageAccount = CloudStorageAccount.Parse(config["AzureQueues:ConnectionString"]);

            using var activator = new BuiltinHandlerActivator();
            activator.Register(() => new NewOrderHandler());
            Configure.With(activator)
                .Transport(t => t.UseAzureStorageQueues(storageAccount, config["AzureQueues:QueueName"]))
                .Start();

            Console.WriteLine("Listening for new orders..");
            Console.WriteLine("Press enter to quit");
            Console.ReadLine();
        }
    }
}
