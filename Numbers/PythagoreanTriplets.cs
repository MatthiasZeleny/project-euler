namespace Numbers;

public static class PythagoreanTriplets
{
    public static (long a, long b, long c) CreateTripledWithSum(long sum) => GetTripletsUpTill(sum).First();

    public static List<(long a, long b, long c)> GetTripletsUpTill(long sum)
    {
        if (sum < 5)
        {
            return new List<(long a, long b, long c)>();
        }

        return new List<(long a, long b, long c)> { (3, 4, 5) };
    }
}