namespace AdventOfCode.Library.Extensions;

public static class StringExtensions
{
    public static IEnumerable<string> SplitIntoLines(this string s, string separator = "\r\n",
        StringSplitOptions options = StringSplitOptions.None)
    {
        return s.Split(separator, options);
    }

    public static int ToInt(this string s) => int.Parse(s);
    
    public static string FindFirst(this string s, IEnumerable<string> args)
    {
        return args
            .Select(arg => new { arg, index = s.IndexOf(arg, StringComparison.Ordinal) })
            .Where(x => x.index >= 0)
            .OrderBy(x => x.index)
            .Select(x => x.arg)
            .First();
    }

    public static string FindLast(this string s, IEnumerable<string> args)
    {
        return args
            .Select(arg => new { arg, index = s.LastIndexOf(arg) })
            .Where(x => x.index >= 0)
            .OrderByDescending(x => x.index)
            .Select(x => x.arg)
            .First();
    }
}