using Numbers.BasicMath;

namespace Problems._003X;

public class Problem0033 : IEulerProblem<long>
{
    public long Example()
    {
        var digitFractions = new List<TwoDigitFraction>
        {
            new(new TwoDigitNumber(9, 8),new TwoDigitNumber(4, 9))
        };
        var digitCancelingFractions = digitFractions.Where(CanCancelByDigits).ToList();

        return digitCancelingFractions.Select(fraction=>new Fraction(fraction.Numerator.AsNumber,  fraction.Denominator.AsNumber).Reduce()).Single().Numerator;
    }

    private static bool CanCancelByDigits(TwoDigitFraction fraction)
    {
        var reducedFraction = new Fraction(fraction.Numerator.AsNumber, fraction.Denominator.AsNumber).Reduce();

        var oneDigitNumeratorTenDigitDenominatorFraction = new Fraction(fraction.Numerator.OneDigit, fraction.Denominator.TenDigit).Reduce();

        return Equals(reducedFraction, oneDigitNumeratorTenDigitDenominatorFraction);
    }

    public long Solution() => 0;

    private class TwoDigitNumber(int tenDigit, int oneDigit)
    {
        public int TenDigit { get; } = tenDigit;
        public int OneDigit { get; } = oneDigit;

        public long AsNumber { get; } = tenDigit*10 + oneDigit;
    }

    private class TwoDigitFraction(TwoDigitNumber numerator, TwoDigitNumber denominator)
    {
        public TwoDigitNumber Numerator { get; } = numerator;
        public TwoDigitNumber Denominator { get; } = denominator;

    }
}