namespace AdventOfCode.Library._2023;

public partial class Day03
{
    protected override IEnumerable<TestCase> ExtraTests()
    {
        const string firstExample = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";
        return
        [
            new TestCase(SolvePart1, firstExample, 4361)
        ];
    }
}