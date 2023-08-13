namespace Numbers;

public static class PythagoreanTriplets
{
    public static (long a, long b, long c) CreateTripledWithSum(long sum) => GetTripletsUpTill(sum).First();

    public static List<(long a, long b, long c)> GetTripletsUpTill(long highestPossibleNumber)
    {
        if (highestPossibleNumber < 5)
        {
            return new List<(long a, long b, long c)>();
        }

        if (highestPossibleNumber < 13)
        {
            return new List<(long a, long b, long c)> { (3, 4, 5) };
        }

        if (highestPossibleNumber < 17)
        {
            return new List<(long a, long b, long c)> { (3, 4, 5), (5, 12, 13) };
        }

        return new List<(long a, long b, long c)>
        {
            (3, 4, 5),
            (5, 12, 13),
            (8, 15, 17)
        };
    }
}