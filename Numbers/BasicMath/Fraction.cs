namespace Numbers.BasicMath;

public class Fraction
{
    public Fraction(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public int Numerator { get; }
    public int Denominator { get; }


    public bool HasSameValueAs(Fraction otherFraction)
    {
        return Numerator * otherFraction.Denominator == Denominator * otherFraction.Numerator;
    }
}