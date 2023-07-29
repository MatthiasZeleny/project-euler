using Numbers;

namespace Problems;

public static class Problem0003
{
    public static long Example() => GetBiggestPrimeFactorFor(13195);

    public static long Solution() => GetBiggestPrimeFactorFor(600851475143);

    private static long GetBiggestPrimeFactorFor(long number) => Primes.FactorsFor(number).Last();
}