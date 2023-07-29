using Numbers;

namespace Problems;

public static class Problem0003
{
    public static int Example() => GetBiggestPrimeFactorFor(13195);

    private static int GetBiggestPrimeFactorFor(int number) => Primes.FactorsFor(number).Last();
}