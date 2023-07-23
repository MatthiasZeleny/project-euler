namespace Problem_0002;

public static class Problem0002
{
    public static int Example()
    {
        return new List<int> { 1, 2, 3, 5, 8 }.Where(number => number % 2 == 0).Sum();
    }
}