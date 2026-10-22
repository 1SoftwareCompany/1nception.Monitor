using One.Inception.Hosting.Heartbeat;
using Microsoft.Extensions.Logging;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace One.Inception.Monitor;

[DataContract(Name = "454fad07-1b15-48b0-8d1d-667d5b1fd398")]
public class InceptionMonitoringProjection : ITrigger,
    ISignalHandle<HeartbeatSignal>
{
    private readonly MonitorContainer monitorContainer;
    private readonly ILogger<InceptionMonitoringProjection> logger;

    public InceptionMonitoringProjection(MonitorContainer monitorContainer, ILogger<InceptionMonitoringProjection> logger)
    {
        this.monitorContainer = monitorContainer;
        this.logger = logger;
    }

    public Task HandleAsync(HeartbeatSignal @event)
    {
        HeartbeatDto data = new HeartbeatDto(@event);
        monitorContainer.Add(data);

        return Task.CompletedTask;
    }
}

