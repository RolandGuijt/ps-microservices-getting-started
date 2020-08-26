using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rebus.Activation;
using Rebus.Config;

namespace GloboTicket.Services.Payment
{
    public class NewOrderWorkerService: BackgroundService
    {
        private readonly ILogger<NewOrderWorkerService> _logger;

        public NewOrderWorkerService(ILogger<NewOrderWorkerService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var storageAccount = CloudStorageAccount.Parse(config["AzureQueues:ConnectionString"]);

            using var activator = new BuiltinHandlerActivator();
            activator.Register(() => new NewOrderHandler());
            Configure.With(activator)
                .Transport(t => t.UseAzureStorageQueues(storageAccount, config["AzureQueues:QueueName"]))
                .Start();

            while (!stoppingToken.IsCancellationRequested)
            {
            }
        }
    }
}
