using System.Numerics;
using Numbers;

namespace Problems._002X;

public class Problem0020 : IEulerProblem<long>
{
    public long Example() => SumOfFactorialDigits(10);

    public long Solution() => SumOfFactorialDigits(100);

    private static long SumOfFactorialDigits(int largestFactor) =>
        Enumerable.Range(1, largestFactor - 1)
            .Select(number => new BigInteger(number))
            .Aggregate((product, factor) => product * factor)
            .ToDigitList()
            .Sum();
}
