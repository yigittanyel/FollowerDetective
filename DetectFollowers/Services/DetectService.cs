using DetectFollowers.Models;
using Newtonsoft.Json;

namespace DetectFollowers.Services;

public class DetectService : IDetectService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;
    public DetectService(HttpClient httpClient, IConfiguration configuration, IEmailService emailService)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _emailService = emailService;
    }

    public async Task<InstagramModel> GetInstagramInfo(string username)
    {
        var request = new HttpRequestMessage();

        request.Method = HttpMethod.Get;
        request.RequestUri = new Uri($"{_configuration["Instagram:ApiUrl"]}/account-info?username={username}");
        request.Headers.Add("X-RapidAPI-Key", _configuration["Instagram:RapidApiKey"]);
        request.Headers.Add("X-RapidAPI-Host", _configuration["Instagram:RapidAPIHost"]);

        using var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        InstagramModel model = JsonConvert.DeserializeObject<InstagramModel>(responseBody);
        return model;
    }
    public async Task<Dictionary<string,int>> GetFollowCount(string username)
    {
        var followersCount = GetInstagramInfo(username).Result.edge_followed_by.count;
        var followingCount = GetInstagramInfo(username).Result.edge_follow.count;

        return new Dictionary<string, int> { { "followersCount", followersCount }, { "followingCount", followingCount } };
    }

    public async Task CheckAndSendEmail()
    {
        var previousCounts = await GetFollowCount("eminem"); 

        var currentCounts = await GetFollowCount("eminem"); 

        if (previousCounts["followersCount"] != currentCounts["followersCount"] ||
            previousCounts["followingCount"] != currentCounts["followingCount"])
        {
            var emailSettings = _configuration.GetSection("EmailSettings").Get<EmailSettings>();

            var previousCountsString = $"Followers: {previousCounts["followersCount"]}, Following: {previousCounts["followingCount"]}";
            var currentCountsString = $"Followers: {currentCounts["followersCount"]}, Following: {currentCounts["followingCount"]}";

            var body = $"Takipçi sayılarında bir değişiklik tespit edildi.\n\nEski takipçi sayıları:\n{previousCountsString}\n\nYeni takipçi sayıları:\n{currentCountsString}";

            await _emailService.SendEmail("tanyelyigit@gmail.com", "Takipçi Sayıları Değişti", body, emailSettings);
        }
    }

}

