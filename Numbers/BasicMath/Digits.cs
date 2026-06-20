using System.Numerics;

namespace Numbers.BasicMath;

public static class Digits
{
    private const long BaseTen = 10;
    public const long HighestDigitBaseTen = BaseTen - 1;

    public static IEnumerable<long> ToDigitListStartingFromHighest(this long number, long digitBase = BaseTen) =>
        ToDigitListStartingFromLowest(number, digitBase).Reverse();

    public static IEnumerable<long> ToDigitListStartingFromHighest(this BigInteger number) =>
        ToDigitListStartingFromLowest(number).Reverse();

    private static IEnumerable<long> ToDigitListStartingFromLowest(long number, long digitBase)
    {
        var temp = number;
        while (temp > 0)
        {
            yield return temp % digitBase;
            temp /= digitBase;
        }
    }

    private static IEnumerable<long> ToDigitListStartingFromLowest(BigInteger number)
    {
        var temp = number;
        while (temp > 0)
        {
            yield return (long)(temp % BaseTen);
            temp /= BaseTen;
        }
    }

    public static List<long> ToDigitListStartingFromHighest(this string line)
    {
        return line.ToList().Select(digit => long.Parse(digit.ToString())).ToList();
    }

    public static List<List<long>> GetConsecutiveDigitsOfLength(this IReadOnlyCollection<long> digits, int length)
    {
        var latestStartingPosition = digits.Count - length + 1;

        return Enumerable
            .Range(0, latestStartingPosition)
            .Select(startingPosition =>
                TakeSubList(digits, startingPosition, length)
            ).ToList();
    }

    private static List<long> TakeSubList(IReadOnlyCollection<long> digits, int startingPosition, int length) =>
        digits.Skip(startingPosition).Take(length).ToList();

    public static readonly IReadOnlySet<BaseTenDigit> DecimalDigits = Enum.GetValues<BaseTenDigit>().ToHashSet();
}