using AdventOfCode.Library.Extensions;

namespace AdventOfCode.Library;

public abstract partial class BaseDay
{
    public abstract Day Day { get; }

    public abstract Year Year { get; }

    public abstract int SolvePart1(string input);
    
    public abstract int SolvePart2(string input);

    protected abstract string Input { get; }

    protected abstract int SolutionPart1 { get; }

    protected abstract int SolutionPart2 { get; }

    protected IEnumerable<TestCase> Tests()
    {
        return
        [
            ..ExtraTests(),
            new TestCase(SolvePart1, Input, SolutionPart1, "Test Part 1"),
            new TestCase(SolvePart2, Input, SolutionPart2, "Test Part 2")
        ];
    }

    public IReadOnlyList<TestResult> RunTests() => Tests().SelectToReadOnlyList(testCase => TestResult.Create(testCase, this));

    protected virtual IEnumerable<TestCase> ExtraTests() => [];
}