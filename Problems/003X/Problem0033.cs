using Numbers.BasicMath;

namespace Problems._003X;

public class Problem0033 : IEulerProblem<long>
{
    public long Example()
    {
        var digitFractions = new List<TwoDigitFraction>
        {
            new(new TwoDigitNumber(9, 8), new TwoDigitNumber(4, 9))
        };
        var digitCancelingFractions = digitFractions.Where(CanCancelByDigits).ToList();

        return digitCancelingFractions
            .Select(fraction => new Fraction(fraction.Numerator.AsNumber, fraction.Denominator.AsNumber).Reduce()).Single()
            .Numerator;
    }

    private static bool CanCancelByDigits(TwoDigitFraction fraction)
    {
        var reducedFraction = new Fraction(fraction.Numerator.AsNumber, fraction.Denominator.AsNumber).Reduce();

        var oneDigitNumeratorTenDigitDenominatorFraction =
            fraction.Numerator.TenDigit == fraction.Denominator.OneDigit
                ? GetMaybeNewFraction(fraction.Numerator.OneDigit, fraction.Denominator.TenDigit)?.Reduce()
                : null;
        var tenDigitNumeratorOneDigitDenominatorFraction =
            fraction.Numerator.OneDigit == fraction.Denominator.TenDigit
                ? GetMaybeNewFraction(fraction.Numerator.TenDigit, fraction.Denominator.OneDigit)?.Reduce()
                : null;
        var tenDigitNumeratorTenDigitDenominatorFraction =
            fraction.Numerator.OneDigit == fraction.Denominator.OneDigit
                ? GetMaybeNewFraction(fraction.Numerator.TenDigit, fraction.Denominator.TenDigit)?.Reduce()
                : null;
        var oneDigitNumeratorOneDigitDenominatorFraction =
            fraction.Numerator.TenDigit == fraction.Denominator.TenDigit
                ? GetMaybeNewFraction(fraction.Numerator.OneDigit, fraction.Denominator.OneDigit)?.Reduce()
                : null;

        return
            Equals(reducedFraction, oneDigitNumeratorTenDigitDenominatorFraction) ||
            Equals(reducedFraction, tenDigitNumeratorOneDigitDenominatorFraction) ||
            Equals(reducedFraction, tenDigitNumeratorTenDigitDenominatorFraction) ||
            Equals(reducedFraction, oneDigitNumeratorOneDigitDenominatorFraction);
    }

    private static Fraction? GetMaybeNewFraction(int numerator, int denominator) =>
        denominator == 0 ? null : new Fraction(numerator, denominator);

    public long Solution()
    {
        var digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        var twoDigitNumbers = digits.SelectMany(oneDigit => digits.Select(tenDigit => new TwoDigitNumber(oneDigit, tenDigit)))
            .Where(number => number.TenDigit != 0).ToList();

        var digitFractions = twoDigitNumbers.SelectMany(numerator =>
            twoDigitNumbers.Select(denominator => new TwoDigitFraction(numerator, denominator)));
        var digitCancelingFractions = digitFractions
            .Where(CannotBeTriviallyReduced)
            .Where(IsLessThenOne)
            .Where(CanCancelByDigits);


        return digitCancelingFractions
            .Select(fraction => new Fraction(fraction.Numerator.AsNumber, fraction.Denominator.AsNumber))
            .Select(fraction=> fraction.Reduce())
            .Aggregate(
                new Fraction(1, 1),
                (product, factor) =>
                    new Fraction(product.Numerator * factor.Numerator, product.Denominator * factor.Denominator).Reduce())
            .Denominator;
    }

    private static bool CannotBeTriviallyReduced(TwoDigitFraction fraction)
    {
        var bothDivisibleByTen = fraction.Denominator.OneDigit == 0 && fraction.Numerator.OneDigit == 0;
        var isDivisibleByEleven =
            fraction.Denominator.AsNumber.IsDivisibleBy(11) && fraction.Numerator.AsNumber.IsDivisibleBy(11);

        return !bothDivisibleByTen && !isDivisibleByEleven;
    }

    private static bool IsLessThenOne(TwoDigitFraction fraction) =>
        fraction.Numerator.AsNumber < fraction.Denominator.AsNumber;

}