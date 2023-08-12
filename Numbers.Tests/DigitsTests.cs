using FluentAssertions;

namespace Numbers.Tests;

public class DigitsTests
{
    [TestCase("")]
    [TestCase("1", 1)]
    [TestCase("2", 2)]
    [TestCase("12", 1, 2)]
    public void ToDigitList_ShouldReturnCorrectDigits(string text, params long[] expectedDigits)
    {
        var digitList = text.ToDigitList();

        digitList.Should().BeEquivalentToWithStrictOrdering(expectedDigits.ToList());
    }

    [Test]
    public void GetConsecutiveDigitsOfLength_SingleElement_ShouldReturnSingleElement()
    {
        var digitTuples = Digits.GetConsecutiveDigitsOfLength(new List<long> { 1 }, 1);

        digitTuples.Should().BeEquivalentToWithStrictOrdering(new List<List<long>> { new() { 1 } });
    }

    [Test]
    public void GetConsecutiveDigitsOfLength_TwoElementsAndLengthOne_ShouldReturnTwoSingleElements()
    {
        var digitTuples = Digits.GetConsecutiveDigitsOfLength(new List<long> { 1, 2 }, 1);

        digitTuples.Should().BeEquivalentToWithStrictOrdering(new List<List<long>>
        {
            new() { 1 },
            new() { 2 }
        });
    }

    [Test]
    public void GetConsecutiveDigitsOfLength_TwoElementsAndLengthTwo_ShouldReturnSingleListWithTwoElements()
    {
        var digitTuples = Digits.GetConsecutiveDigitsOfLength(new List<long> { 1, 2 }, 2);

        digitTuples.Should().BeEquivalentToWithStrictOrdering(new List<List<long>>
        {
            new() { 1, 2 }
        });
    }

    [Test]
    public void GetConsecutiveDigitsOfLength_ThreeElementsAndLengthTwo_ShouldReturnTwoListsWithTwoElements()
    {
        var digitTuples = Digits.GetConsecutiveDigitsOfLength(new List<long> { 1, 2, 3 }, 2);

        digitTuples.Should().BeEquivalentToWithStrictOrdering(new List<List<long>>
        {
            new() { 1, 2 },
            new() { 2, 3 }
        });
    }
}