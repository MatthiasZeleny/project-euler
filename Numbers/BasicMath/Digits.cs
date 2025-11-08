using System.Numerics;

namespace Numbers.BasicMath;

public static class Digits
{
    private const long BaseTen = 10;

    public static IEnumerable<long> ToDigitList(this long number) =>
        CreateEnumerableStartingFromLowest(number).Reverse();

    public static IEnumerable<long> ToDigitList(this BigInteger number) =>
        CreateEnumerableStartingFromLowest(number).Reverse();

    private static IEnumerable<long> CreateEnumerableStartingFromLowest(long number)
    {
        var temp = number;
        while (temp > 0)
        {
            yield return temp % BaseTen;
            temp /= BaseTen;
        }
    }

    private static IEnumerable<long> CreateEnumerableStartingFromLowest(BigInteger number)
    {
        var temp = number;
        while (temp > 0)
        {
            yield return (long)(temp % BaseTen);
            temp /= BaseTen;
        }
    }

    public static List<long> ToDigitList(this string line)
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

    public static readonly IReadOnlySet<int> DecimalDigits = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
}