using Xunit;

namespace AdventOfCode.Library._2023;

public partial class Day02
{
    [Fact]
    public void Part1() => Assert.Equal(2331, SolvePart1(Input));
    
    [Fact]
    public void Part2() => Assert.Equal(71585, SolvePart2(Input));
}