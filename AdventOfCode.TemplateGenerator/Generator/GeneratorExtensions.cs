namespace AdventOfCode.TemplateGenerator;

public static class GeneratorExtensions
{
    public static string ReplaceYear(this string template, int year) => template.Replace("{{YearNumber}}", year.ToString());
    
    public static string ReplaceDay(this string template, int day) => template.Replace("{{DayNumber}}", day.ToString());
    
    public static string ReplaceInput(this string template, string input) => template.Replace("{{Input}}", input);

    public static string ReplaceSolutions(this string template, int solutionPart1, int solutionPart2)
    {
        return template
            .Replace("{{SolutionPart1}}", solutionPart1.ToString())
            .Replace("{{SolutionPart2}}", solutionPart2.ToString());
    }
}