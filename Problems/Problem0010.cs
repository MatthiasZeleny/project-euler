using Numbers;

namespace Problems;

public class Problem0010 : IEulerProblem
{
    public long Example() => Primes.Create().TakeWhile(prime => prime < 10).Sum();

    public long Solution() => 0;
}