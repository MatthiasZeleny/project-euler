using Numbers.SpecialNumbers.Primes;

namespace Problems._001X;

public class Problem0010 : IEulerProblem<long>
{
    public long Example() => GetSumOfPrimesBelow(10);

    public long Solution() => GetSumOfPrimesBelow(2_000_000);

    private static long GetSumOfPrimesBelow(long threshold)
    {
        return Prime.Create()
            .TakeWhile(prime => prime < threshold)
            .Sum();
    }
}