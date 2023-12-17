using FluentAssertions;

namespace Numbers.Tests;

public class PythagoreanTripleTests
{
    [TestCase(3 + 4 + 5, 3, 4, 5)]
    [TestCase(9 + 12 + 15, 9, 12, 15)]
    public void CreateTripledWithSum_ShouldReturnFittingTriplet(int sum, int a, int b, int c)
    {
        var triplet = PythagoreanTriple.CreateTripledWithSum(sum);

        triplet.Should().Be(PythagoreanTriple.Create(a, b, c));
    }

    [Test]
    public void GetTripletsUpTill_Four_ReturnsEmptyList()
    {
        var triplets = PythagoreanTriple.GetTripletsUpTill(4);

        triplets.Should().BeEquivalentToWithStrictOrdering(new List<PythagoreanTriple>());
    }

    [Test]
    public void GetTripletsUpTill_Five_ReturnsSingleTriplet()
    {
        var triplet = PythagoreanTriple.GetTripletsUpTill(5);

        triplet.Should().BeEquivalentToWithStrictOrdering(
            new List<PythagoreanTriple>
                { PythagoreanTriple.Create(3, 4, 5) });
    }

    [Test]
    public void GetTripletsUpTill_Thirteen_ReturnsTwoTriplets()
    {
        var triplet = PythagoreanTriple.GetTripletsUpTill(13);

        triplet.Should().BeEquivalentToWithStrictOrdering(
            new List<PythagoreanTriple>
            {
                PythagoreanTriple.Create(3, 4, 5),
                PythagoreanTriple.Create(5, 12, 13),
                PythagoreanTriple.Create(6, 8, 10)
            });
    }

    [Test]
    public void GetTripletsUpTill_Seventeen_ReturnsThreeTriplets()
    {
        var triplet = PythagoreanTriple.GetTripletsUpTill(17);

        triplet.Should().BeEquivalentToWithStrictOrdering(
            new List<PythagoreanTriple>
            {
                PythagoreanTriple.Create(3, 4, 5),
                PythagoreanTriple.Create(5, 12, 13),
                PythagoreanTriple.Create(6, 8, 10),
                PythagoreanTriple.Create(8, 15, 17),
                PythagoreanTriple.Create(9, 12, 15)
            });
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    public void GetTripletsUpTill_ReturnsListContainingPreviousOne(long highestNumber)
    {
        var higher = PythagoreanTriple.GetTripletsUpTill(highestNumber);
        var lower = PythagoreanTriple.GetTripletsUpTill(highestNumber - 1);

        higher.Should().ContainInConsecutiveOrder(lower);
    }
}
