using AdventOfCode.Library;

namespace AdventOfCode.TemplateGenerator;

public static class GeneratorExtensions
{
    public static string ReplaceYear(this string template, Year year) => template.Replace("{{YearNumber}}", ((int)year).ToString());
    
    public static string ReplaceDay(this string template, Day day) => template.Replace("{{DayNumber}}", ((int)day).ToString("D2"));
    
    public static string ReplaceInput(this string template, string input) => template.Replace("{{Input}}", input);

    public static string ReplaceSolutions(this string template, int solutionPart1, int solutionPart2)
    {
        return template
            .Replace("{{SolutionPart1}}", solutionPart1.ToString())
            .Replace("{{SolutionPart2}}", solutionPart2.ToString());
    }
}