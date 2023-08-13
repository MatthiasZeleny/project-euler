using FluentAssertions;

namespace Numbers.Tests;

public class PythagoreanTripletsTests
{
    [TestCase(3 + 4 + 5, 3, 4, 5)]
    public void CreateTripledWithSum_ShouldReturnFittingTriplet(long sum, long a, long b, long c)
    {
        var triplet = PythagoreanTriplets.CreateTripledWithSum(sum);

        triplet.Should().Be((3, 4, 5));
    }
}