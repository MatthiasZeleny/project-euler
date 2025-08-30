using Numbers.SpecialNumbers.Primes;

namespace Problems._000X;

/// <summary>
/// <a href="https://projecteuler.net/problem=3"/>
/// </summary>
public class Problem0003 : IEulerProblem<long>
{
    public long Example() => GetBiggestPrimeFactorFor(13195);

    public long Solution() => GetBiggestPrimeFactorFor(600851475143);

    private static long GetBiggestPrimeFactorFor(long number) => PrimeFactorRepresentation.For(number).AsList().Last();
}
