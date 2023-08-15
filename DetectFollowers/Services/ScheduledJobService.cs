namespace DetectFollowers.Services;

public class ScheduledJobService
{
    private readonly IDetectService _detectService;

    public ScheduledJobService(IDetectService detectService)
    {
        _detectService = detectService;
    }

    public async Task RunScheduledTask()
    {
        while (true) 
        {
            await Task.Delay(TimeSpan.FromSeconds(10)); 
            
            await _detectService.CheckAndSendEmail();
        }
    }

}
