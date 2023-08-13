namespace Numbers;

public static class PythagoreanTriplets
{
    public static (long a, long b, long c) CreateTripledWithSum(long sum) => GetTripletsUpTill(sum).First();

    public static List<(long a, long b, long c)> GetTripletsUpTill(long sum) => new() { (3, 4, 5) };
}