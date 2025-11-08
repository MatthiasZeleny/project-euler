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

    [Test]
    [TestCase(1,1)]
    [TestCase(1,2)]
    [TestCase(2,1)]
    [TestCase(2,3)]
    public void Reduce_IrreducibleShould_ReturnSame(int numerator, int denominator)
    {
        var fraction = new Fraction(numerator,denominator);

        var reduced = fraction.Reduce();
        
        reduced.Denominator.Should().Be(denominator);
        reduced.Numerator.Should().Be(numerator);
    }

    [Test]
    [TestCase(2,2)]
    [TestCase(3,3)]
    public void Reduce_NumeratorSameAsDenominator_ShouldReturnOneDividedByOne(int numerator, int denominator)
    {
        var fraction = new Fraction(numerator,denominator);

        var reduced = fraction.Reduce();
        
        reduced.Denominator.Should().Be(1);
        reduced.Numerator.Should().Be(1);
    }

    [Test]
    [TestCase(2,2*2, 2)]
    [TestCase(3,3*5,5)]
    public void Reduce_IsNumeratorContainedByDenominator_ShouldReturnOneDividedByRest(int numerator, int denominator, int reducedDenominator)
    {
        var fraction = new Fraction(numerator,denominator);

        var reduced = fraction.Reduce();

        reduced.Numerator.Should().Be(1);
        reduced.Denominator.Should().Be(reducedDenominator);
    }
    
    [Test]
    [TestCase(2*2,2, 2)]
    [TestCase(3*5,3,5)]
    public void Reduce_IsDenominatorContainedByNumerator_ShouldReturnRestDividedByOne(int numerator, int denominator, int reducedNumerator)
    {
        var fraction = new Fraction(numerator,denominator);

        var reduced = fraction.Reduce();

        reduced.Denominator.Should().Be(1);
        reduced.Numerator.Should().Be(reducedNumerator);
    }
    
    [Test]
    [TestCase(2*3,3*5,2,5)]
    public void Reduce_NumeratorAndDenominatorHaveANonTrivialGreatestCommonDivisor_ShouldReturnRestDividedByOne(int numerator, int denominator, int reducedNumerator, int reducedDenominator)
    {
        var fraction = new Fraction(numerator,denominator);

        var reduced = fraction.Reduce();

        reduced.Numerator.Should().Be(reducedNumerator);
        reduced.Denominator.Should().Be(reducedDenominator);
    }
}