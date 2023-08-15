namespace Numbers;

public static class PythagoreanTriplets
{
    public static (long a, long b, long c) CreateTripledWithSum(long sum) =>
        GetTripletsUpTill(sum).First(tuple => tuple.a + tuple.b + tuple.c == sum);

    public static IEnumerable<(long a, long b, long c)> GetTripletsUpTill(long highestPossibleNumber)
    {
        for (var a = 1; a <= highestPossibleNumber; a++)
        {
            for (var b = 1; b <= highestPossibleNumber; b++)
            {
                for (var c = 1; c <= highestPossibleNumber; c++)
                {
                    if ((a < b && b < c) is false)
                    {
                        continue;
                    }

                    if (FulfillsPythagoreanTriple(a, b, c))
                    {
                        yield return (a, b, c);
                    }
                }
            }
        }
    }

    private static bool FulfillsPythagoreanTriple(int a, int b, int c)
    {
        return a * a + b * b == c * c;
    }
}