using Numbers;

namespace Problems._000X;

public class Problem0003 : IEulerProblem<long>
{
    public long Example() => GetBiggestPrimeFactorFor(13195);

    public long Solution() => GetBiggestPrimeFactorFor(600851475143);

    private static long GetBiggestPrimeFactorFor(long number) => PrimeFactorRepresentation.For(number).AsList().Last();
}