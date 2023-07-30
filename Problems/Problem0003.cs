using Numbers;

namespace Problems;

public class Problem0003 : IEulerProblem
{
    public long Example() => GetBiggestPrimeFactorFor(13195);

    public long Solution() => GetBiggestPrimeFactorFor(600851475143);

    private static long GetBiggestPrimeFactorFor(long number) => Primes.FactorsFor(number).Last();
}