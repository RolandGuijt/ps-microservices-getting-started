using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Rebus.Activation;
using Rebus.Config;

namespace GloboTicket.Services.Payment
{
    public class NewOrderWorkerService: BackgroundService
    {
        private readonly IConfiguration _config;

        public NewOrderWorkerService(IConfiguration config)
        {
            _config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var storageAccount = CloudStorageAccount.Parse(_config["AzureQueues:ConnectionString"]);

            using var activator = new BuiltinHandlerActivator();
            activator.Register(() => new NewOrderHandler());
            Configure.With(activator)
                .Transport(t => t.UseAzureStorageQueues(storageAccount, _config["AzureQueues:QueueName"]))
                .Start();

            await Task.Delay(Timeout.InfiniteTimeSpan, stoppingToken);
        }
    }
}
