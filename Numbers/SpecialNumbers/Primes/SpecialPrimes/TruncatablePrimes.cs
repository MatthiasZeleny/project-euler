using Numbers.BasicMath;

namespace Numbers.SpecialNumbers.Primes.SpecialPrimes;

public static class TruncatablePrimes
{

    public static bool IsTruncatablePrime(this long number, PrimeChecker primeChecker)
    {
        return primeChecker.IsPrime(number) && GetRightTruncated(number).All(primeChecker.IsPrime) && GetLeftTruncated(number).All(primeChecker.IsPrime);
    }

    private static IEnumerable<long> GetRightTruncated(long number)
    {
        var rest = number;

        do
        {
            rest /= 10;

            yield return rest;
        } while (rest > 9);
    }

    private static IEnumerable<long> GetLeftTruncated(long number)
    {
        
        var rest = number;
        long current = 0;
        long factor = 1;
        while (rest > 9)
        {
            var digit = rest % 10;
            rest /= 10;
            current += factor * digit;
            factor *= 10;
            yield return current;
        }
        
    }
}