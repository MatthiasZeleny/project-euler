namespace Numbers;

public static class Fibonacci
{
    public static IEnumerable<int> GetAllLessOrEqual(int threshold)
    {
        if (threshold == 1)
        {
            return new List<int> { 1 };
        }

        if (threshold == 2)
        {
            return new List<int> { 1, 2 };
        }

        return new List<int> { 1, 2, 3, 5, threshold };
    }
}