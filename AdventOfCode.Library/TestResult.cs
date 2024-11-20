using System.Diagnostics;

namespace AdventOfCode.Library;

public class TestResult
{
    public TestCase TestCase { get; }
    public TimeSpan Duration { get; }
    public int Actual { get; }
    public bool IsSuccess { get; }

    public BaseDay BaseDay { get; }

    private TestResult(TestCase testCase, TimeSpan duration, int actual, bool isSuccess, BaseDay baseDay)
    {
        TestCase = testCase;
        Duration = duration;
        Actual = actual;
        IsSuccess = isSuccess;
        BaseDay = baseDay;
    }

    public static TestResult Create(TestCase testCase, BaseDay day)
    {
        var sw = Stopwatch.StartNew();
        var actual = testCase.Solver(testCase.Input);
        var duration = sw.Elapsed;
        
        var isSuccess = actual.Equals(testCase.Expected);
        
        return new TestResult(testCase, duration, actual, isSuccess, day);
    }
}