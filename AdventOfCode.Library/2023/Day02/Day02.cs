using AdventOfCode.Library.Extensions;

namespace AdventOfCode.Library._2023;

public partial class Day02 : BaseDay
{
    public override Day Day => Day.Day02;
    
    public override Year Year => Year.Year2023;
    
    public override int SolvePart1(string input)
    {
        var lines = input.SplitIntoLines();
        var processedGames = ProcessGames(lines);

        var validGames = processedGames.WhereToReadOnlyList(g =>
        {
            var maxRed = GetMaxColorPowerInGame(g.Value, "red");
            var maxBlue = GetMaxColorPowerInGame(g.Value, "blue");
            var maxGreen = GetMaxColorPowerInGame(g.Value, "green");

            if (maxRed > ElfSubset["red"]) return false;
            if (maxBlue > ElfSubset["blue"]) return false;
            if (maxGreen > ElfSubset["green"]) return false;

            return true;
        });

        return validGames.Sum(v => v.Key);
    }

    public override int SolvePart2(string input)
    {
        var lines = input.SplitIntoLines();
        var processedGames = ProcessGames(lines);
        
        var validGames = processedGames.SelectToReadOnlyList(g =>
        {
            var maxRed = GetMaxColorPowerInGame(g.Value, "red");
            var maxBlue = GetMaxColorPowerInGame(g.Value, "blue");
            var maxGreen = GetMaxColorPowerInGame(g.Value, "green");

            return maxRed * maxBlue * maxGreen;
        });
        
        return validGames.Sum();
    }
    
    private static List<KeyValuePair<int, IReadOnlyList<Dictionary<string, int>>>> ProcessGames(IEnumerable<string> lines)
    {
        var processedGames = lines.ToDictionary(
            l => l.Split(": ").First().Split(' ').Last().ToInt(),
            l =>
            {
                var subsets = l.Split(": ").Last().Split("; ");
                return subsets.SelectToReadOnlyList(subset =>
                {
                    return subset.Split(", ").ToDictionary(
                        keySelector: key => key.Split(' ').Last(),
                        elementSelector: element => element.Split(' ').First().ToInt());
                });
            }).ToList();
        return processedGames;
    }

    private static int GetMaxColorPowerInGame(IReadOnlyList<Dictionary<string, int>> g, string color)
    {
        return g.SelectToReadOnlyList(v => v.GetValueOrDefault(color, 0)).Max();
    }
    
    private Dictionary<string, int> ElfSubset = new()
    {
        { "red", 12 },
        { "green", 13 },
        { "blue", 14 }
    };
}