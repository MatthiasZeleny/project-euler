using FluentAssertions;

namespace Numbers.Tests;

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
}