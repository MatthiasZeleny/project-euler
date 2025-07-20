namespace Numbers.BasicMath;

public static class NumberExtensions
{
    private const int TenBase = 10;

    public static bool IsDivisibleBy(this long number, long divisor) => number % divisor == 0;

    public static bool IsEven(this long number) => number.IsDivisibleBy(2);

    public static bool IsPalindrome(this long number)
    {
        var digitsStartingFromLowest = GetDigitsAsListStartingFromLowest(number);

        var numberWithReveredDigits = CreateNumberFromDigitListStartingFromHighest(digitsStartingFromLowest);

        return numberWithReveredDigits == number;
    }

    public static long CreateNumberFromDigitListStartingFromHighest(IEnumerable<long> digitsStartingFromLowest) =>
        digitsStartingFromLowest
            .Aggregate(0L, (current, nextDigit) => current * TenBase + nextDigit);

    private static IEnumerable<long> GetDigitsAsListStartingFromLowest(long number)
    {
        var rest = number;

        var digitsStartingFromLowest = new List<long>();

        while (rest > 0)
        {
            digitsStartingFromLowest.Add(rest % TenBase);

            rest /= TenBase;
        }

        return digitsStartingFromLowest;
    }

    public static long Squared(this long number) => number * number;

    public static int DigitsToNumber(this IEnumerable<int> digits) => digits.Aggregate(0, (current, nextDigit) => current * 10 + nextDigit);
}
