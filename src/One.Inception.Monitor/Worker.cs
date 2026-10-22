using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace One.Inception.Monitor.Api;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> log;
    private readonly IInceptionHost inceptionHost;

    public Worker(ILogger<Worker> log, IInceptionHost inceptionHost)
    {
        this.log = log;
        this.inceptionHost = inceptionHost;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        log.LogInformation("Starting service...");

        await inceptionHost.StartAsync().ConfigureAwait(false);

        log.LogInformation("Service started!");
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        log.LogInformation("Stopping service...");

        await inceptionHost.StopAsync().ConfigureAwait(false); ;

        log.LogInformation("Service stopped");
    }
}
