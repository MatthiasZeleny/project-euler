namespace Numbers;

public static class Grids
{
    public static long PossibilitiesToTravelAQuadraticGrid(long gridSize)
    {
        var dictionary = new Dictionary<(long Width, long Height), long>();

        Add(dictionary, new Grid(gridSize, gridSize - 1), 1);
        Add(dictionary, new Grid(gridSize - 1, gridSize), 1);

        while (dictionary.Keys.FirstOrDefault(tuple => tuple is { Width: > 0, Height: > 0 }) is var (width, height))
        {
            if (width is 0 || height is 0)
            {
                break;
            }

            SplitIntoTwoSubGrids(dictionary, width, height);
        }

        return dictionary.Values.Sum();
    }

    private static void SplitIntoTwoSubGrids(
        Dictionary<(long Width, long Height), long> dictionary,
        long width,
        long height)
    {
        var count = dictionary[(width, height)];
        Add(dictionary, new Grid(width, height - 1), count);
        Add(dictionary, new Grid(width - 1, height), count);
        dictionary.Remove((width, height));
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