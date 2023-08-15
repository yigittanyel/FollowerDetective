namespace DetectFollowers.Services;

public class ScheduledTaskHostedService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public ScheduledTaskHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var taskService = scope.ServiceProvider.GetRequiredService<ScheduledJobService>();
                await taskService.RunScheduledTask();
            }

            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
}

