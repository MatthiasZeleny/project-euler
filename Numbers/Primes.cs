namespace Numbers;

public static class Primes
{
    private const int NumberToAddSinceIDoNotTrustRounding = 1;

    public static IEnumerable<long> CreatePrimesUpUntil(long upperBound) =>
        CreateUpToNthPrime(ComputeUpperBoundForPrimeCount(upperBound));

    public static IEnumerable<long> CreateUpToNthPrime(int numberOfPrimes)
    {
        var naturals = NumberList.NaturalNumbers()
            .Skip(1);
        var primes = new List<long>(numberOfPrimes);

        foreach (var natural in naturals)
        {
            if (primes.Any(prime => natural.IsDivisibleBy(prime)))
            {
                continue;
            }

            primes.Add(natural);

            yield return natural;
        }
    }

    private static int ComputeUpperBoundForPrimeCount(long upperBound)
    {
        if (upperBound == 1)
        {
            return 1;
        }

        // This is from Estimates of Some Functions Over Primes without R.H. by Pierre Dusart (https://arxiv.org/abs/1002.0442)
        var upperBoundForNumberOfPrimes = upperBound / Math.Log(upperBound) * (1 + 1.2762 / Math.Log(upperBound));
        var cappedMax = Math.Min(upperBoundForNumberOfPrimes + NumberToAddSinceIDoNotTrustRounding, int.MaxValue/8);

        return (int)cappedMax;
    }
}