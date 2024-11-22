using AdventOfCode.TemplateGenerator.APIServices;

namespace AdventOfCode.TemplateGenerator;

public class GeneratorService
{
    private const string LibraryPath = "C:\\Users\\Usuario\\RiderProjects\\AdventOfCode\\AdventOfCode.Library"; // Adjust this path as needed
    
    private InputFetcher _inputFetcher;
    
    private SolutionFetcher _solutionFetcher;
    
    public GeneratorService(InputFetcher inputFetcher, SolutionFetcher solutionFetcher)
    {
        _inputFetcher = inputFetcher;
        _solutionFetcher = solutionFetcher;
    }
    
    public async Task GenerateDay(int year, int day)
    {
        var input = await _inputFetcher.FetchInputAsync(year, day);
        var solutionPart1 = await _solutionFetcher.FetchSolutionAsync(year, day, 1, input);
        var solutionPart2 = await _solutionFetcher.FetchSolutionAsync(year, day, 2, input);
        
        GenerateBaseClass(year, day);
        GenerateInput(year, day, input);
        GenerateSolutions(year, day, solutionPart1, solutionPart2);
        GenerateTests(year, day);
    }

    private void GenerateBaseClass(int year, int day)
    {
        var template = TemplatesService.BaseClassTemplate
            .ReplaceYear(year)
            .ReplaceDay(day);

        var folderPath = GetDestinationPath(year, day);
        var fileName = $"Day{day:D2}.cs";
        WriteToFile(folderPath, fileName, template);
    }

    private void GenerateInput(int year, int day, string input)
    {
        var template = TemplatesService.InputTemplate
            .ReplaceYear(year)
            .ReplaceDay(day)
            .ReplaceInput(input);

        var folderPath = GetDestinationPath(year, day);
        var fileName = $"Day{day:D2}.Input.cs";
        WriteToFile(folderPath, fileName, template);
    }

    private void GenerateSolutions(int year, int day, int solutionPart1, int solutionPart2)
    {
        var template = TemplatesService.SolutionsTemplate
            .ReplaceYear(year)
            .ReplaceDay(day)
            .ReplaceSolutions(solutionPart1, solutionPart2);

        var folderPath = GetDestinationPath(year, day);
        var fileName = $"Day{day:D2}.Solutions.cs";
        WriteToFile(folderPath, fileName, template);
    }

    private void GenerateTests(int year, int day)
    {
        var template = TemplatesService.TestsTemplate
            .ReplaceYear(year)
            .ReplaceDay(day);

        var folderPath = GetDestinationPath(year, day);
        var fileName = $"Day{day:D2}.Tests.cs";
        WriteToFile(folderPath, fileName, template);
    }

    private static string GetDestinationPath(int year, int day)
    {
        var destinationFolder = Path.Combine(LibraryPath, year.ToString(), $"Day{day:D2}");
        if (!Directory.Exists(destinationFolder))
        {
            Directory.CreateDirectory(destinationFolder);
        }
        return destinationFolder;
    }

    private static void WriteToFile(string folderPath, string fileName, string content)
    {
        var fullPath = Path.Combine(folderPath, fileName);
        File.WriteAllText(fullPath, content);
    }
}
