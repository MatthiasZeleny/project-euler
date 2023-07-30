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

    [Test]
    public void IsPalindrome_One_ShouldBeTrue()
    {
        var isPalindrome = 1L.IsPalindrome();

        isPalindrome.Should().BeTrue();
    }
}