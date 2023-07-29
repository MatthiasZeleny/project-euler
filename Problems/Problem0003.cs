namespace Problems;

public static class Problem0003
{
    public static int Example() => GetPrimeFactorsFor13195().Last();

    private static IEnumerable<int> GetPrimeFactorsFor13195() => new List<int> { 5, 7, 13, 29 };
}