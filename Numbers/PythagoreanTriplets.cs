namespace Numbers;

public static class PythagoreanTriplets
{
    public static (long a, long b, long c) CreateTripledWithSum(long sum) => GetTripletsUpTill(sum).First();

    public static IEnumerable<(long a, long b, long c)> GetTripletsUpTill(long highestPossibleNumber)
    {
        for (var a = 1; a <= highestPossibleNumber; a++)
        {
            for (var b = a + 1; b <= highestPossibleNumber; b++)
            {
                for (var c = b + 1; c <= highestPossibleNumber; c++)
                {
                    if (a * a + b * b == c * c)
                    {
                        yield return (a, b, c);
                    }
                }
            }
        }
    }
}