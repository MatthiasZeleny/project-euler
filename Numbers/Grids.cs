namespace Numbers;

public static class Grids
{
    public static long PossibilitiesToTravelAQuadraticGrid(long gridSize)
    {
        var dictionary = new Dictionary<(long Width, long Height), long>();

        RegisterSubGrids(dictionary, gridSize, gridSize, 1);

        while (dictionary.Keys.FirstOrDefault(HasMoreThanOnePath) is var (width, height))
        {
            var hasOnlyOnePath = width is 0 || height is 0;
            if (hasOnlyOnePath)
            {
                break;
            }

            SplitIntoTwoSubGrids(dictionary, width, height);
        }

        return dictionary.Values.Sum();
    }

    private static bool HasMoreThanOnePath((long Width, long Height) tuple)
    {
        return tuple is { Width: > 0, Height: > 0 };
    }

    private static void SplitIntoTwoSubGrids(
        Dictionary<(long Width, long Height), long> dictionary,
        long width,
        long height)
    {
        var count = dictionary[(width, height)];

        RegisterSubGrids(dictionary, width, height, count);

        dictionary.Remove((width, height));
    }

    private static void RegisterSubGrids(Dictionary<(long Width, long Height), long> dictionary, long width,
        long height, long count)
    {
        Add(dictionary, new Grid(width, height - 1), count);
        Add(dictionary, new Grid(width - 1, height), count);
    }

    private static void Add(Dictionary<(long Width, long Height), long> dictionary, Grid value, long count)
    {
        if (dictionary.TryAdd(value.NormalizedSize, count) is false)
        {
            dictionary[value.NormalizedSize] += count;
        }
    }

    private class Grid
    {
        private long Width { get; }
        private long Height { get; }

        public Grid(long width, long height)
        {
            Width = width;
            Height = height;
        }

        public (long Width, long Height) NormalizedSize => Width > Height ? (Width, Height) : (Height, Width);
    }
}