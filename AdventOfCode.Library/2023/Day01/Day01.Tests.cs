using Xunit;

namespace AdventOfCode.Library._2023;

public partial class Day01
{
    [Fact]
    public void Day01_Part1() => Assert.Equal(54697, SolvePart1(Input));
    
    [Fact]
    public void Day01_Part2() => Assert.Equal(54885, SolvePart2(Input));
}