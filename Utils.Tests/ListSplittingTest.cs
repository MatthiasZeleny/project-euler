namespace Utils.Tests;

public class ListSplittingTest
{
    [Test]
    public void GetEverySplit_EmptyList_ShouldContainSingleEmptyElement()
    {
        var everySplit = new List<int>().GetEverySplit();

        var splitList = everySplit.Should().ContainSingle().Subject;
        splitList.First.Should().BeEmpty();
        splitList.Second.Should().BeEmpty();
    }

    [Test]
    public void GetEverySplit_SingleElement_ShouldContainBothPossibleCombinations()
    {
        var everySplit = new List<int> { 1 }.GetEverySplit();

        everySplit.Should().BeEquivalentTo(
        [
            new ListSplitIntoTwoParts<int>([], [1]),
            new ListSplitIntoTwoParts<int>([1], [])
        ]);
    }

    [Test]
    public void GetEverySplit_TwoElements_ShouldContainBothPossibleCombinations()
    {
        var everySplit = new List<int> { 1, 2 }.GetEverySplit();

        everySplit.Should().BeEquivalentTo(
        [
            new ListSplitIntoTwoParts<int>([], [1, 2]),
            new ListSplitIntoTwoParts<int>([1], [2]),
            new ListSplitIntoTwoParts<int>([1, 2], [])
        ]);
    }
}
