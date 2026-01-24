namespace Numbers.BasicMath;

public static class TwoDigitFractionExtensions
{
    public static bool IsLessThenOne(this TwoDigitFraction fraction) =>
        fraction.Numerator.AsNumber < fraction.Denominator.AsNumber;

    public static bool CannotBeTriviallyReduced(this TwoDigitFraction fraction)
    {
        var bothDivisibleByTen = fraction.Denominator.OneDigit == 0 && fraction.Numerator.OneDigit == 0;
        var isDivisibleByEleven =
            fraction.Denominator.AsNumber.IsDivisibleBy(11) && fraction.Numerator.AsNumber.IsDivisibleBy(11);

        return !bothDivisibleByTen && !isDivisibleByEleven;
    }
}