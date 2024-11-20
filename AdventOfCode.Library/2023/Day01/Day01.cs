using AdventOfCode.Library.Extensions;

namespace AdventOfCode.Library._2023;

public partial class Day01 : BaseDay
{
    public override int Day => 1;
    
    public override int Year => 2023;

    public override int SolvePart1(string input)
    {
        var lines = input.SplitIntoLines();

        var processedNumbers = lines.Select(l =>
            {
                var digits = l.Where(char.IsDigit).Select(c => c.ToInt()).ToList();
                return new List<int> { digits.First(), digits.Last() };
            })
            .Select(n => string.Join("", n).ToInt());

        return processedNumbers.Sum();
    }

    public override int SolvePart2(string input)
    {
        var lines = input.SplitIntoLines();

        var processedNumbers = lines.Select(l =>
        {
            var possibleNumbers = _dictionary.Values.Select(v => v.ToString()).ToList();
            var possibleWords = _dictionary.Keys.ToList();
            var possibleValues = possibleNumbers.Concat(possibleWords).ToList();

            var firstNumber = TranslateNumber(l.FindFirst(possibleValues));
            var lastNumber = TranslateNumber(l.FindLast(possibleValues));

            return $"{firstNumber}{lastNumber}".ToInt();
        });

        return processedNumbers.Sum();
    }

    private int TranslateNumber(string number)
    {
        if (_dictionary.ContainsKey(number))
        {
            return _dictionary[number];
        }

        return number.ToInt();
    }

    private Dictionary<string, int> _dictionary = new()
    {
        { "zero", 0 },
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
    };
}