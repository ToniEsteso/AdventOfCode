namespace AdventOfCode.TemplateGenerator;

public static class TemplatesService
{
    public static string BaseClassTemplate { get; set; }
    
    public static string InputTemplate { get; set; }
    
    public static string SolutionsTemplate { get; set; }
    
    public static string TestsTemplate { get; set; }

    static TemplatesService()
    {
        BaseClassTemplate = ReadTemplateContent("DayXX.txt");
        InputTemplate = ReadTemplateContent("DayXX.Input.txt");
        SolutionsTemplate = ReadTemplateContent("DayXX.Solutions.txt");
        TestsTemplate = ReadTemplateContent("DayXX.Tests.txt");
    }
    
    private static string ReadTemplateContent(string templateName)
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", templateName);
        return File.ReadAllText(filePath);
    }
}