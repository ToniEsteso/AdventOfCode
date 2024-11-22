using AdventOfCode.TemplateGenerator;
using AdventOfCode.TemplateGenerator.APIServices;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main(string[] args)
    {
        var day = 3;
        var year = 2023;
        var services = new ServiceCollection();
        ConfigureServices(services);

        var serviceProvider = services.BuildServiceProvider();

        var generatorService = serviceProvider.GetRequiredService<GeneratorService>();

        await generatorService.GenerateDay(year, day);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddTransient<InputFetcher>();
        services.AddTransient<SolutionFetcher>();
        services.AddTransient<GeneratorService>();
    }
}