namespace AdventOfCode.Library.Extensions;

public static class IntExtensions
{
    public static IEnumerable<int> To(this int value, int target) => Enumerable.Range(value, target);
}