using AdventOfCode.Library;

namespace AdventOfCode.TemplateGenerator;

public sealed class GeneratorParameters
{
    public Day Day { get; init; }
    public Year Year { get; init; }
    public bool OverwriteExisting { get; init; }
    public bool GenerateBaseClass { get; init; }
    public bool GenerateInput { get; init; }
    public bool GenerateSolutions { get; init; }
    public bool GenerateTests { get; init; }

    public static GeneratorParameters ParametersForNewFile(Day day, Year year) =>
        new()
        {
            Day = day,
            Year = year,
            OverwriteExisting = false,
            GenerateBaseClass = true,
            GenerateInput = true,
            GenerateSolutions = true,
            GenerateTests = true
        };
    
    public static GeneratorParameters ParametersForReset(Day day, Year year) =>
        new()
        {
            Day = day,
            Year = year,
            OverwriteExisting = true,
            GenerateBaseClass = true,
            GenerateInput = true,
            GenerateSolutions = true,
            GenerateTests = true
        };
}
