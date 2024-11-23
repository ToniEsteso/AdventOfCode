using AdventOfCode.Library;
using AdventOfCode.Library.Extensions;
using AdventOfCode.TemplateGenerator;
using AdventOfCode.TemplateGenerator.APIServices;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);

        List<GeneratorParameters> daysToCreate =
        [
            GeneratorParameters.ParametersForNewFile(Day.Day03, Year.Year2023)
        ];
        
        var serviceProvider = services.BuildServiceProvider();
        var generatorService = serviceProvider.GetRequiredService<GeneratorService>();

        var t = daysToCreate.Select(p => generatorService.GenerateDay(p)).ToArray();
        await Task.WhenAll(t);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddTransient<InputFetcher>();
        services.AddTransient<SolutionFetcher>();
        services.AddTransient<GeneratorService>();
    }
}