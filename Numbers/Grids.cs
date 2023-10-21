namespace Numbers;

public static class Grids
{
    public static long PossibilitiesToTravelAQuadraticGrid(long numberOfEdgesInEachDirection)
    {
        var dictionary = new Dictionary<(long edgeCountWidth, long edgeCoundHeight), long>();
        Add(dictionary, new Grid(numberOfEdgesInEachDirection, numberOfEdgesInEachDirection), 1);

        while (dictionary.Keys.FirstOrDefault(HasMoreThanOnePath) is var (edgeCountWidth, edgeCountHeight)
               && (edgeCountWidth, edgeCountHeight) != default)
        {
            SplitIntoTwoSubGrids(dictionary, edgeCountWidth, edgeCountHeight);
        }

        return dictionary.Values.Sum();
    }

    private static bool HasMoreThanOnePath((long EdgeCountWidth, long EdgeCountHeight) tuple)
    {
        return tuple is { EdgeCountWidth: > 0, EdgeCountHeight: > 0 };
    }

    private static void SplitIntoTwoSubGrids(
        Dictionary<(long edgeCountWidth, long edgeCoundHeight), long> dictionary,
        long width,
        long height)
    {
        var count = dictionary[(width, height)];

        RegisterSubGrids(dictionary, width, height, count);

        dictionary.Remove((width, height));
    }

    private static void RegisterSubGrids(Dictionary<(long edgeCountWidth, long edgeCoundHeight), long> dictionary, long width,
        long height, long count)
    {
        Add(dictionary, new Grid(width, height - 1), count);
        Add(dictionary, new Grid(width - 1, height), count);
    }

    private static void Add(Dictionary<(long edgeCountWidth, long edgeCoundHeight), long> dictionary, Grid value, long count)
    {
        if (dictionary.TryAdd(value.NormalizedSize, count) is false)
        {
            dictionary[value.NormalizedSize] += count;
        }
    }

}