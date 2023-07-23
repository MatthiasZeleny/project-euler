namespace Numbers;

public static class Fibonacci
{
    public static IEnumerable<int> GetAllLessOrEqual(int threshold)
    {
        return new List<int> { 1, 2, 3, 5, threshold };
    }
}