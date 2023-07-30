using Numbers;

namespace Problems;

public class Problem0007 : IEulerProblem
{
    public long Example() => Primes.Create().Skip(6 - 1).First();

    public long Solution() => 0;
}