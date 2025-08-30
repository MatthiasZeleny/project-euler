using Numbers.BasicMath;

namespace Problems._000X;

/// <summary>
/// <a href="https://projecteuler.net/problem=1"/>
/// </summary>
public class Problem0001 : IEulerProblem<long>
{
    public long Example() => GetSumOfAllMultiplesOfThreeAndFiveBelow(10);

    public long Solution() => GetSumOfAllMultiplesOfThreeAndFiveBelow(1000);

    private static long GetSumOfAllMultiplesOfThreeAndFiveBelow(long threshold) =>
        NumberList.Below(threshold)
            .Where(DivisibleByFourOrFive)
            .Sum();

    private static bool DivisibleByFourOrFive(long number) =>
        number.IsDivisibleBy(3)
        || number.IsDivisibleBy(5);
}
