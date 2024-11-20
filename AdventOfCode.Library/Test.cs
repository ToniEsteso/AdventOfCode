namespace AdventOfCode.Library;

public class TestCase
{
    public string TestName { get; }
    public string Input { get; }
    public int Expected { get; }

    public Func<string, int> Solver { get; }

    public TestCase(Func<string, int> solver, string input, int expected, string? testName = null)
    {
        Solver = solver;
        TestName = testName ?? "Unnamed test";
        Input = input;
        Expected = expected;
    }
}