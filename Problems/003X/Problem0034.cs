using Numbers.BasicMath;

namespace Problems._003X;

/// <summary>
/// https://projecteuler.net/problem=34
/// </summary>
public class Problem0034 : IEulerProblem<long>
{
    public long Example() => new List<long> { 145 }
        .Where(number => number.ToDigitList().Select(Factorial).Sum() == number).Sum();

    public long Solution()
    {
        var maxDigitCount = NumberList.NaturalNumbers()
            .TakeWhile(digitCount => digitCount * Factorial(9) > TenToThePowerOf(digitCount))
            .Last() + 1;

        return NumberList.NumbersBetween(3, TenToThePowerOf(maxDigitCount))
            .Where(number => number.ToDigitList().Select(Factorial).Sum() == number).Sum();
    }

    private long TenToThePowerOf(long digitCount)
    {
        if (digitCount == 0) return 1;

        return 10 * TenToThePowerOf(digitCount - 1);
    }

    private static long Factorial(long digit)
    {
        if (digit == 0) return 1;

        return digit * Factorial(digit - 1);
    }
}