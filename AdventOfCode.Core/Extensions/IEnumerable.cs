namespace AdventOfCode.Library.Extensions;

public static class IEnumerableExtensions
{
    public static IReadOnlyList<TResult> SelectToReadOnlyList<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
        return source.Select(selector).ToList();
    }
    
    public static IReadOnlyList<TResult> SelectToReadOnlyList<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
    {
        return source.Select(selector).ToList();
    }
    
    public static IReadOnlyList<TSource> WhereToReadOnlyList<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> filter)
    {
        return source.Where(filter).ToList();
    }
}