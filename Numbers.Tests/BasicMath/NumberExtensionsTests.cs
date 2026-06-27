using FluentAssertions;
using Numbers.BasicMath;

namespace Numbers.Tests.BasicMath;

public class NumberExtensionsTests
{
    [Test]
    public void IsPalindrome_Problem004Example_ShouldBeTrue()
    {
        var isPalindrome = 9009L.IsPalindrome();

        isPalindrome.Should().BeTrue();
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    public void IsPalindrome_SingleDigit_ShouldBeTrue(long number)
    {
        var isPalindrome = number.IsPalindrome();

        isPalindrome.Should().BeTrue();
    }

    [TestCase(0b1)]
    [TestCase(0b11)]
    [TestCase(0b101)]
    public void IsPalindrome_BinaryPalindrome_ShouldBeTrue(long number)
    {
        var isPalindrome = number.IsPalindrome(2);

        isPalindrome.Should().BeTrue();
    }

    [TestCase(2)]
    [TestCase(11)]
    public void IsPalindrome_BinaryNonPalindromeButBaseTenPalindrome_ShouldBeTrue(long number)
    {
        var isPalindrome = number.IsPalindrome(2);

        isPalindrome.Should().BeFalse();
    }

    [Test]
    public void IsPalindrome_Ten_ShouldBeFalse()
    {
        var isPalindrome = 10L.IsPalindrome();

        isPalindrome.Should().BeFalse();
    }

    [Test]
    public void IsPalindrome_Eleven_ShouldBeTrue()
    {
        var isPalindrome = 11L.IsPalindrome();

        isPalindrome.Should().BeTrue();
    }

    [TestCase(1, 1)]
    [TestCase(2, 4)]
    [TestCase(3, 9)]
    public void Squared(long number, long expected)
    {
        var squared = number.Squared();

        squared.Should().Be(expected);
    }
}