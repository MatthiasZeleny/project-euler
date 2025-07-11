namespace Utils;

public static class ListSplitting
{

    public static IEnumerable<ListSplitIntoTwoParts<T>> GetEverySplit<T>(this IReadOnlyCollection<T> list)
    {
        var listCount = list.Count;
        var elementsInFirstSubListOptions = listCount.Then(count => Enumerable.Range(0, count + 1));

        foreach (var option in elementsInFirstSubListOptions)
        {
            yield return new ListSplitIntoTwoParts<T>(
                list.Take(option).ToList(), list.TakeLast(list.Count - option).ToList());
        }
    }
}
