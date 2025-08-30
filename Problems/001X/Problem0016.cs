using System.Numerics;
using Numbers.BasicMath;

namespace Problems._001X;

/// <summary>
/// <a href="https://projecteuler.net/problem=16"/>
/// </summary>
public class Problem0016 : IEulerProblem<long>
{
    public long Example() => GetDigitSumOfTwoToThePowerOf(15);

    public long Solution() => GetDigitSumOfTwoToThePowerOf(1_000);

    private static long GetDigitSumOfTwoToThePowerOf(int count) =>
        TwoToThePowerOf(count)
            .ToDigitList()
            .Sum();

    private static BigInteger TwoToThePowerOf(int count) =>
        Enumerable
            .Repeat(BigInteger.Parse("2"), count)
            .Aggregate(BigInteger.One, (product, nextFactor) => product * nextFactor);
}