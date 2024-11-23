using AdventOfCode.Library;

namespace AdventOfCode.Runner;

public static class ResultPrinter
{
    public static void PrintResult(IReadOnlyList<TestResult> resultsForDay)
    {
        var day = resultsForDay[0].BaseDay;
        Console.WriteLine($"Results for day {day.Day} - {day.Year}");
        foreach (var testResult in resultsForDay)
        {
            Console.WriteLine(testResult.TestCase.TestName);
            Console.WriteLine($"  Success: {testResult.IsSuccess}");
            Console.WriteLine($"  Time ellapsed: {FormatTimeSpan(testResult.Duration)}");
            Console.WriteLine($"  Memory used: {FormatMemory(testResult.MemoryUsed)}");
        }
    }
    
    public static string FormatMemory(long bytes)
    {
        if (bytes < 1024)
            return $"{bytes} B"; // Bytes
        else if (bytes < 1024 * 1024)
            return $"{bytes / 1024.0:F2} KB"; // Kilobytes
        else if (bytes < 1024 * 1024 * 1024)
            return $"{bytes / (1024.0 * 1024.0):F2} MB"; // Megabytes
        else
            return $"{bytes / (1024.0 * 1024.0 * 1024.0):F2} GB"; // Gigabytes
    }
    
    public static string FormatTimeSpan(TimeSpan timeSpan) => $"{timeSpan.TotalMilliseconds:F2} ms";
}