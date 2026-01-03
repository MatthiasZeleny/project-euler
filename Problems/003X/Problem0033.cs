using Numbers.BasicMath;

namespace Problems._003X;

public class Problem0033 : IEulerProblem<long>
{
    public long Example()
    {
        var digitFractions = new List<TwoDigitFraction>
        {
            new(new TwoDigitNumber(Digit.Nine, Digit.Eight), new TwoDigitNumber(Digit.Four, Digit.Nine))
        };
        var digitCancelingFractions = digitFractions.Where(CanCancelByDigits).ToList();

        return digitCancelingFractions
            .Select(fraction => new Fraction(fraction.Numerator.AsNumber, fraction.Denominator.AsNumber).Reduce()).Single()
            .Numerator;
    }

    private static bool CanCancelByDigits(TwoDigitFraction fraction)
    {
        var numerator = fraction.Numerator;
        var denominator = fraction.Denominator;
        
        var reducedFraction = new Fraction(numerator.AsNumber, denominator.AsNumber).Reduce();

        var oneDigitNumeratorTenDigitDenominatorFraction =
            numerator.TenDigit == denominator.OneDigit
                ? GetMaybeNewFraction(numerator.OneDigit.AsNumber(), denominator.TenDigit.AsNumber())?.Reduce()
                : null;
        var tenDigitNumeratorOneDigitDenominatorFraction =
            numerator.OneDigit == denominator.TenDigit
                ? GetMaybeNewFraction(numerator.TenDigit.AsNumber(), denominator.OneDigit.AsNumber())?.Reduce()
                : null;
        var tenDigitNumeratorTenDigitDenominatorFraction =
            numerator.OneDigit == denominator.OneDigit
                ? GetMaybeNewFraction(numerator.TenDigit.AsNumber(), denominator.TenDigit.AsNumber())?.Reduce()
                : null;
        var oneDigitNumeratorOneDigitDenominatorFraction =
            numerator.TenDigit == denominator.TenDigit
                ? GetMaybeNewFraction(numerator.OneDigit.AsNumber(), denominator.OneDigit.AsNumber())?.Reduce()
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
        var numbersFromTenToNinetyNine = NumbersFromTenToNinetyNine();

        var digitFractions = CreateEveryPossibleCombination(numbersFromTenToNinetyNine);
        
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

    private static IEnumerable<TwoDigitFraction> CreateEveryPossibleCombination(List<TwoDigitNumber> numbersFromTenToNinetyNine)
    {
        return numbersFromTenToNinetyNine.SelectMany(numerator =>
            numbersFromTenToNinetyNine.Select(denominator => new TwoDigitFraction(numerator, denominator)));
    }

    private static List<TwoDigitNumber> NumbersFromTenToNinetyNine()
    {
        var digits = Enum.GetValues<Digit>();

        var numbersFromTenToNinetyNine = digits.SelectMany(oneDigit => digits.Select(tenDigit => new TwoDigitNumber(oneDigit, tenDigit)))
            .Where(number => number.TenDigit != Digit.Zero).ToList();

        return numbersFromTenToNinetyNine;
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