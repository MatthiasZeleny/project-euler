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
}