namespace Utils;

public static class ListSplitting
{

    public static IEnumerable<ListSplitIntoTwoParts<T>> GetEverySplit<T>(IReadOnlyCollection<T> list)
    {
        if (list.Count == 0)
        {
            return [new([], [])];
        }

        return [new ListSplitIntoTwoParts<T>([], list), new ListSplitIntoTwoParts<T>(list, [])];
    }
}
