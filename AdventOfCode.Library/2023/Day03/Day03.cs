using System.Text.RegularExpressions;
using AdventOfCode.Library.Extensions;

namespace AdventOfCode.Library._2023;

public partial class Day03 : BaseDay
{
    public override Day Day => Day.Day03;
    
    public override Year Year => Year.Year2023;

    public override int SolvePart1(string input)
    {
        var lines = input.SplitIntoLines();

        var numbers = lines.SelectToReadOnlyList((l, lineNumber) =>
        {
            var pattern = @"\d+";
        
            var matches = Regex.Matches(l, pattern);
            var numbers = matches.SelectToReadOnlyList(n =>
            {
                return new Coordinate(
                    XStart: n.Index,
                    XEnd: n.Index + n.Length,
                    Y: lineNumber,
                    Value: n.Value.ToInt())
            })
            
            return numbers;
        });
        return default;
    }

    public override int SolvePart2(string input)
    {
        return default;
    }
    
    private sealed record Coordinate(int XStart, int XEnd, int Y, int Value);
}
