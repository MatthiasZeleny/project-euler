namespace Numbers.SpecialNumbers.Primes.SpecialPrimes;

public static class TruncatablePrimes
{

    public static bool IsTruncatablePrime(this long number, PrimeChecker primeChecker)
    {
        return primeChecker.IsPrime(number) && GetRightTruncated(number).All(primeChecker.IsPrime);
    }

    private static IEnumerable<long> GetRightTruncated(long number)
    {
        var rest = number;

        do
        {
            rest /= 10;

            yield return rest;
        } while (rest > 10);
    }
}