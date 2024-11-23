using AdventOfCode.Library;

namespace AdventOfCode.TemplateGenerator.APIServices;

public class SolutionFetcher
{
    private readonly HttpClient _httpClient;

    public SolutionFetcher(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> FetchSolutionAsync(Year year, Day day, Part part, string input)
    {
        var url = $"https://advent.fly.dev/solve/{(int)year}/{(int)day}/{(int)part}";
        var content = new StringContent(input);

        var response = await _httpClient.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to submit solution for day {day}. Status code: {response.StatusCode}");
        }
        
        return int.Parse(await response.Content.ReadAsStringAsync());
    }
}