using DetectFollowers.Models;

namespace DetectFollowers.Services;

public interface IDetectService
{
    Task<InstagramModel> GetInstagramInfo(string username);
    Task<Dictionary<string, int>> GetFollowCount(string username);
    Task CheckAndSendEmail();
}
