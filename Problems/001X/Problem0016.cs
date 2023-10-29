using System.Numerics;
using Numbers;

namespace Problems._001X;

public class Problem0016 : IEulerProblem<long>
{
    public long Example() => GetDigitSumOfTwoToThePowerOf(15);

    public long Solution() => 0;

    private static long GetDigitSumOfTwoToThePowerOf(int count) =>
        TwoToThePowerOf(count)
            .ToDigitList()
            .Sum();

    private static BigInteger TwoToThePowerOf(int count) =>
        Enumerable
            .Repeat(BigInteger.Parse("2"), count)
            .Aggregate(BigInteger.One, (product, nextFactor) => product * nextFactor);
}