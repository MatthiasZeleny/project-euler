namespace Numbers;

public static class NumberList
{
    public static IEnumerable<int> Below(int threshold) => Enumerable.Range(1, threshold - 1);
}