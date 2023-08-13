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


    [Test]
    public void GetTripletsUpTill_Five_ReturnsSingleTriplet()
    {
        var triplet = PythagoreanTriplets.GetTripletsUpTill(5);

        triplet.Should().BeEquivalentToWithStrictOrdering(new List<(long a, long b, long c)> { (3, 4, 5) });
    }

    [Test]
    public void GetTripletsUpTill_Four_ReturnsEmptyList()
    {
        var triplet = PythagoreanTriplets.GetTripletsUpTill(4);

        triplet.Should().BeEquivalentToWithStrictOrdering(new List<(long a, long b, long c)>());
    }
}