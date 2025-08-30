using Numbers.BasicMath;
using Numbers.SpecialNumbers;

namespace Problems._002X;

/// <summary>
/// <a href="https://projecteuler.net/problem=21"/>
/// </summary>
public class Problem0021 : IEulerProblem<long>
{
    public long Example() => GetSumOfAmicableNumbersBelow(1_000);

    public long Solution() => GetSumOfAmicableNumbersBelow(10_000);

    private static long GetSumOfAmicableNumbersBelow(long below) =>
        NumberList.Below(below)
            .Where(number => number.IsAmicableNumber())
            .Sum();
}
