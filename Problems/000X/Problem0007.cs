using Numbers;

namespace Problems._000X;

public class Problem0007 : IEulerProblem<long>
{
    public long Example() => GetPrimeNumber(6);

    public long Solution() => GetPrimeNumber(10001);

    private static long GetPrimeNumber(int number) =>
        Primes.Create()
            .Skip(number - 1)
            .First();
}