namespace Utils.Data;

public static class CombinationsExtensions
{
    public static IEnumerable<(int a, int b)> CreateAllCombinationsWith(this IReadOnlyCollection<int> aRange,
        IReadOnlyCollection<int> bRange)
    {
        var candidates = aRange.ToList();
        var allCombinations = candidates.SelectMany(a => bRange.Select(b => (a, b)));

        return allCombinations;
    }
}
