using FluentAssertions;
using Numbers.BasicMath;

namespace Numbers.Tests.BasicMath;

public class FractionTests
{

    [Test]
    public void Denominator_ShouldContainValueOfDenominator()
    {
        var fraction = new Fraction(1, 2);

        fraction.Denominator.Should().Be(2);
    }

    [Test]
    public void Numerator_ShouldContainValueOfNumerator()
    {
        var fraction = new Fraction(1, 2);

        fraction.Numerator.Should().Be(1);
    }

    [Test]
    public void HasSameValue_SameObject_ShouldReturnTrue()
    {
        var fraction = new Fraction(3,6);

        var hasSameValueAs = fraction.HasSameValueAs(fraction);
        
        hasSameValueAs.Should().BeTrue();
    }


    [Test]
    public void HasSameValue_SameValues_ShouldReturnTrue()
    {
        var fraction = new Fraction(3,6);
        var otherFraction = new Fraction(3,6);

        var hasSameValueAs = fraction.HasSameValueAs(otherFraction);
        
        hasSameValueAs.Should().BeTrue();
    }

    [Test]
    public void HasSameValue_DifferentQuotient_ShouldReturnTrue()
    {
        var fraction = new Fraction(3,6);
        var otherFraction = new Fraction(2,6);

        var hasSameValueAs = fraction.HasSameValueAs(otherFraction);
        
        hasSameValueAs.Should().BeFalse();
    }

    [Test]
    public void HasSameValue_SameQuotient_ShouldReturnTrue()
    {
        var fraction = new Fraction(3,6);
        var otherFraction = new Fraction(1,2);

        var hasSameValueAs = fraction.HasSameValueAs(otherFraction);
        
        hasSameValueAs.Should().BeTrue();
    }
}