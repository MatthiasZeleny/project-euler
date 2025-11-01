using Numbers.SpecialNumbers.Primes;

namespace Numbers.BasicMath;

public class Fraction
{
    public Fraction(long numerator, long denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public long Numerator { get; }
    public long Denominator { get; }


    public bool HasSameValueAs(Fraction otherFraction)
    {
        return Numerator * otherFraction.Denominator == Denominator * otherFraction.Numerator;
    }

    public Fraction Reduce()
    {
        var greatestCommonDivisor = PrimeFactorRepresentation.For(Numerator).GreatestCommonDivisor(PrimeFactorRepresentation.For(Denominator)).AsNumber();
        
        return new Fraction(Numerator/greatestCommonDivisor, Denominator/greatestCommonDivisor);
    }
}