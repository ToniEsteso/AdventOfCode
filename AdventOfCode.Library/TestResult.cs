using System.Diagnostics;
using AdventOfCode.Library.Extensions;

namespace AdventOfCode.Library;

public class TestResult
{
    public TestCase TestCase { get; }
    
    public TimeSpan Duration { get; }
    
    public int Actual { get; }
    
    public bool IsSuccess { get; }

    public BaseDay BaseDay { get; }
    
    public long MemoryUsed { get; }

    private TestResult(TestCase testCase, TimeSpan duration, int actual, bool isSuccess, BaseDay baseDay, long memoryUsed)
    {
        TestCase = testCase;
        Duration = duration;
        Actual = actual;
        IsSuccess = isSuccess;
        BaseDay = baseDay;
        MemoryUsed = memoryUsed;
    }

    public static TestResult Create(TestCase testCase, BaseDay day)
    {
        foreach (var i in 1.To(5))
        {
            testCase.Solver(testCase.Input);
        }
        var sw = Stopwatch.StartNew();
        var memoryBefore = GC.GetTotalMemory(true);
        var actual = testCase.Solver(testCase.Input);
        var memoryAfter = GC.GetTotalMemory(false);
        var duration = sw.Elapsed;
        
        var isSuccess = actual.Equals(testCase.Expected);
        
        return new TestResult(testCase, duration, actual, isSuccess, day, memoryAfter - memoryBefore);
    }
}