namespace Numbers.BasicMath;

public static class NumberExtensions
{
    private const int TenBase = 10;

    public static bool IsDivisibleBy(this long number, long divisor) => number % divisor == 0;

    public static bool IsEven(this long number) => number.IsDivisibleBy(2);

    public static bool IsPalindrome(this long number, long digitBase = TenBase)
    {
        var digitsStartingFromHighest = number.ToDigitListStartingFromHighest(digitBase);

        var numberWithReveredDigits = CreateNumberFromDigitListStartingFromLowest(digitsStartingFromHighest.Reverse(), digitBase);

        return numberWithReveredDigits == number;
    }

    public static long CreateNumberFromDigitListStartingFromLowest(IEnumerable<long> digitsStartingFromLowest, long digitBase = TenBase) =>
        digitsStartingFromLowest
            .Aggregate(0L, (current, nextDigit) => current * digitBase + nextDigit);

    public static long Squared(this long number) => number * number;

    public static int DigitsToNumber(this IEnumerable<int> digits) =>
        digits.Aggregate(0, (current, nextDigit) => current * 10 + nextDigit);
}