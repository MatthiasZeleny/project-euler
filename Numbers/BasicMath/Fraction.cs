using Numbers.SpecialNumbers.Primes;

namespace Numbers.BasicMath;

public class Fraction
{

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    public Fraction(long numerator, long denominator)
    {
        if (denominator == 0) throw new ArgumentException("denominator cannot be zero");

        Numerator = numerator;
        Denominator = denominator;
    }

    public long Numerator { get; }

    public long Denominator { get; }

    public bool HasSameValueAs(Fraction otherFraction) =>
        Numerator * otherFraction.Denominator == Denominator * otherFraction.Numerator;

    public Fraction Reduce()
    {
        if (Numerator == 0)
        {
            return new Fraction(0, 1);
        }
        var greatestCommonDivisor = PrimeFactorRepresentation.For(Numerator)
            .GreatestCommonDivisor(PrimeFactorRepresentation.For(Denominator)).AsNumber();

        return new Fraction(Numerator / greatestCommonDivisor, Denominator / greatestCommonDivisor);
    }

    private bool Equals(Fraction other) => Numerator == other.Numerator && Denominator == other.Denominator;

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((Fraction)obj);
    }
}