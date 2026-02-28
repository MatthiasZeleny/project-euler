using Numbers.BasicMath;

namespace Problems._003X;

/// <summary>
/// https://projecteuler.net/problem=34
/// </summary>
public class Problem0034 : IEulerProblem<long>
{
    /// <summary>
    /// Quote: "Note: as 1!=1 and 2!=2 are not sums they are not included."
    /// </summary>
    private const long LowestCandidate = 3;

    /// <summary>
    /// 1! + 4! + 5! = 1 + 24 + 120 = 145 fulfills <see cref="IsTheFactorialOfTheirDigitsEqualToThemselves"/>.
    /// </summary>
    private const long ExampleNumber = 145;

    public long Example()
    {
        var candidates = new List<long> {
            ExampleNumber
        };

        return GetSumOfNumberWhereTheFactorialOfTheirDigitsIsEqualToThemselves(candidates);
    }

    public long Solution()
    {
        var maxDigitCount = GetMaxPossibleDigitCount();

        var candidates = GetAllCandidates(maxDigitCount);

        return GetSumOfNumberWhereTheFactorialOfTheirDigitsIsEqualToThemselves(candidates);
    }

    private static IEnumerable<long> GetAllCandidates(long maxDigitCount) => NumberList.NumbersBetween(LowestCandidate, TenToThePowerOf(maxDigitCount));

    private static long GetMaxPossibleDigitCount()
    {
        var highestDigitCountWhereTheSumOfTheFactorialsAlwaysHigherThanTheMaximumNumberWithThatDigitCount = NumberList.NaturalNumbers()
            .TakeWhile(digitCount => digitCount * Factorial(Digits.HighestDigitBaseTen) > TenToThePowerOf(digitCount))
            .Last();

        return highestDigitCountWhereTheSumOfTheFactorialsAlwaysHigherThanTheMaximumNumberWithThatDigitCount + 1;
    }

    private static long GetSumOfNumberWhereTheFactorialOfTheirDigitsIsEqualToThemselves(IEnumerable<long> candidates)
    {
        return candidates
            .Where(IsTheFactorialOfTheirDigitsEqualToThemselves).Sum();
    }

    private static bool IsTheFactorialOfTheirDigitsEqualToThemselves(long number)
    {
        var digits = number.ToDigitList();

        var sumOfTheFactorialOfTheirDigits = digits.Select(Factorial).Sum();

        return sumOfTheFactorialOfTheirDigits == number;
    }

    private static long TenToThePowerOf(long digitCount)
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