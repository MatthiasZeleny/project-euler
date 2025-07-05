namespace Utils.Tests;

public class ListSplittingTest
{
    [Test]
    public void GetEverySplit_EmptyList_ShouldContainSingleEmptyElement()
    {
        var everySplit = ListSplitting.GetEverySplit(new List<int>());

        var splitList = everySplit.Should().ContainSingle().Subject;
        splitList.First.Should().BeEmpty();
        splitList.Second.Should().BeEmpty();
    }

    [Test]
    public void GetEverySplit_SingleElement_ShouldContainBothPossibleCombinations()
    {
        var everySplit = ListSplitting.GetEverySplit(new List<int> { 1 });

        everySplit.Should().BeEquivalentTo(
        [
            new ListSplitIntoTwoParts<int>([], [1]),
            new ListSplitIntoTwoParts<int>([1], [])
        ]);
    }

    [Test]
    public void GetEverySplit_TwoElements_ShouldContainBothPossibleCombinations()
    {
        var everySplit = ListSplitting.GetEverySplit(new List<int> { 1, 2 });

        everySplit.Should().BeEquivalentTo(
        [
            new ListSplitIntoTwoParts<int>([], [1, 2]),
            new ListSplitIntoTwoParts<int>([1], [2]),
            new ListSplitIntoTwoParts<int>([1, 2], [])
        ]);
    }
}
