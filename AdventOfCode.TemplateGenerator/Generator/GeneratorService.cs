using AdventOfCode.Library;
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
    
    public async Task GenerateDay(GeneratorParameters p)
    {
        var input = await _inputFetcher.FetchInputAsync(p.Year, p.Day);
        var solutionPart1 = await _solutionFetcher.FetchSolutionAsync(p.Year, p.Day, Part.Part1, input);
        var solutionPart2 = await _solutionFetcher.FetchSolutionAsync(p.Year, p.Day, Part.Part2, input);
        
        var replacedBaseClass = p.GenerateBaseClass ?  GenerateBaseClass(p) : null;
        var replacedInput = p.GenerateInput ? GenerateInput(p, input) : null;
        var replacedSolutions = p.GenerateSolutions ? GenerateSolutions(p, solutionPart1, solutionPart2) : null;
        var replacedTests = p.GenerateTests ? GenerateTests(p) : null;

        var overwrite = p.OverwriteExisting;
        
        var folderPath = GetDestinationPath(p);
        
        if (replacedBaseClass is not null)
        {
            var fileName = GetFileName(p, FileType.BaseClass);
            WriteToFile(folderPath, fileName, replacedBaseClass, overwrite);
        }
        
        if (replacedInput is not null)
        {
            var fileName = GetFileName(p, FileType.Input);
            WriteToFile(folderPath, fileName, replacedInput, overwrite);
        }
        
        if (replacedSolutions is not null)
        {
            var fileName = GetFileName(p, FileType.Solutions);
            WriteToFile(folderPath, fileName, replacedSolutions, overwrite);
        }
        
        if (replacedTests is not null)
        {
            var fileName = GetFileName(p, FileType.Tests);
            WriteToFile(folderPath, fileName, replacedTests, overwrite);
        }
    }

    private static string GenerateBaseClass(GeneratorParameters p) => 
        TemplatesService.BaseClassTemplate.ReplaceYear(p.Year).ReplaceDay(p.Day);

    private static string GenerateInput(GeneratorParameters p, string input) => 
        TemplatesService.InputTemplate.ReplaceYear(p.Year).ReplaceDay(p.Day).ReplaceInput(input);

    private static string GenerateSolutions(GeneratorParameters parameters, int solutionPart1, int solutionPart2) => 
        TemplatesService.SolutionsTemplate.ReplaceYear(parameters.Year).ReplaceDay(parameters.Day).ReplaceSolutions(solutionPart1, solutionPart2);

    private static string GenerateTests(GeneratorParameters parameters) => 
        TemplatesService.TestsTemplate.ReplaceYear(parameters.Year).ReplaceDay(parameters.Day);

    private static string GetDestinationPath(GeneratorParameters parameters)
    {
        var destinationFolder = Path.Combine(LibraryPath, ((int)parameters.Year).ToString(), $"Day{((int)parameters.Day):D2}");
        if (!Directory.Exists(destinationFolder))
        {
            Directory.CreateDirectory(destinationFolder);
        }
        return destinationFolder;
    }

    private static void WriteToFile(string folderPath, string fileName, string content, bool overwrite = false)
    {
        var filePath = Path.Combine(folderPath, fileName);
        if (IsFileReadyToBeUsed(filePath) is false || overwrite)
        {
            File.WriteAllText(filePath, content);
        }

        Console.WriteLine($"{filePath} - OK");
    }

    private static string GetFileName(GeneratorParameters p, FileType fileType)
    {
        var formattedDay = FormatDay(p.Day);
        return fileType switch
        {
            FileType.BaseClass => $"{formattedDay}.cs",
            FileType.Input => $"{formattedDay}.Input.cs",
            FileType.Solutions => $"{formattedDay}.Solutions.cs",
            FileType.Tests => $"{formattedDay}.Tests.cs"
        };
    }
    
    private static string FormatDay(Day day) => $"Day{((int)day):D2}";
    
    private static bool IsFileReadyToBeUsed(string filePath)
    {
        if (File.Exists(filePath) is false)
        {
            return false;
        }

        var fileInfo = new FileInfo(filePath);
        return fileInfo.Length != 0;
    }
}
