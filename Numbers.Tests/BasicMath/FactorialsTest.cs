using FluentAssertions;
using Numbers.BasicMath;

namespace Numbers.Tests.BasicMath;

public class FactorialsTest
{

    [TestCase(0,1)]
    [TestCase(1,1)]
    [TestCase(2,2)]
    [TestCase(3,6)]
    public void Factorial_ShouldReturnExpectedResult(long number, long expected)
    {
        var result = number.Factorial();
        
        result.Should().Be(expected);
    }
}