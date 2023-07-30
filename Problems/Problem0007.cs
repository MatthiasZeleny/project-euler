using Numbers;

namespace Problems;

public class Problem0007 : IEulerProblem
{
    public long Example() => GetPrimeNumber(6);

    public long Solution() => 0;

    private static long GetPrimeNumber(int number) =>
        Primes.Create()
            .Skip(number - 1)
            .First();
}