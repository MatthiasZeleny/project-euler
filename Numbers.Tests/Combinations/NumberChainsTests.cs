using FluentAssertions;
using Numbers.Combinations;

namespace Numbers.Tests.Combinations;

[TestFixture]
public class NumberChainsTests
{

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void Chain_SingleElement_ShouldReturnSingleElement(int element)
    {
        var result = NumberChains.Chain([element]);
        
        result.Should().Be(element);
    }
    
    [Test]
    [TestCase(12,1,2)]
    [TestCase(123,12,3)]
    [TestCase(123, 1,23)]
    public void Chain_MultipleElements_ShouldReturnChainedResult(long expected, params long[] elements)
    {
        var result = NumberChains.Chain(elements.ToList());
        
        result.Should().Be(expected);
    }
}