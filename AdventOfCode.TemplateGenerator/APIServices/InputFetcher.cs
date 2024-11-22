namespace AdventOfCode.TemplateGenerator.APIServices;

public class InputFetcher
{
    private readonly HttpClient _httpClient;
    private readonly string _cookie = "53616c7465645f5f649f6781dd0d5ff4b59aa72cdcde6e51f9ec1b69619ebf63b622889ccef59ea53d9fa61f20da3b38a11b7fef84a95d9edc79cb6f9014c2c1";

    public InputFetcher(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> FetchInputAsync(int year, int day)
    {
        string url = $"https://adventofcode.com/{year}/day/{day}/input";
        _httpClient.DefaultRequestHeaders.Add("Cookie", $"session={_cookie}"); // Add your session cookie
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to fetch input for day {day}. Status code: {response.StatusCode}");
        }

        return await response.Content.ReadAsStringAsync();
    }
}
