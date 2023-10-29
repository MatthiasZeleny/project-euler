using System.Numerics;
using FluentAssertions;

namespace Numbers.Tests;

public class DigitsTests
{
    [TestCase(0)]
    [TestCase(1, 1)]
    [TestCase(9, 9)]
    [TestCase(10, 1, 0)]
    [TestCase(210, 2, 1, 0)]
    public void ToDigitList_Number_ShouldReturnCorrectList(long number, params long[] expectedDigits)
    {
        var digitList = number.ToDigitList();

        digitList.Should().BeEquivalentToWithStrictOrdering(expectedDigits);
    }

    [TestCase(0)]
    [TestCase(1, 1)]
    [TestCase(9, 9)]
    [TestCase(10, 1, 0)]
    [TestCase(210, 2, 1, 0)]
    public void ToDigitList_BigIntegerNumber_ShouldReturnCorrectList(long number, params long[] expectedDigits)
    {
        var digitList = (BigInteger.One * number).ToDigitList();

        digitList.Should().BeEquivalentToWithStrictOrdering(expectedDigits);
    }

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
        var digitTuples = new List<long> { 1 }.GetConsecutiveDigitsOfLength(1);

        digitTuples.Should().BeEquivalentToWithStrictOrdering(new List<List<long>> { new() { 1 } });
    }

    [Test]
    public void GetConsecutiveDigitsOfLength_TwoElementsAndLengthOne_ShouldReturnTwoSingleElements()
    {
        var digitTuples = new List<long> { 1, 2 }.GetConsecutiveDigitsOfLength(1);

        digitTuples.Should().BeEquivalentToWithStrictOrdering(new List<List<long>>
        {
            new() { 1 },
            new() { 2 }
        });
    }

    [Test]
    public void GetConsecutiveDigitsOfLength_TwoElementsAndLengthTwo_ShouldReturnSingleListWithTwoElements()
    {
        var digitTuples = new List<long> { 1, 2 }.GetConsecutiveDigitsOfLength(2);

        digitTuples.Should().BeEquivalentToWithStrictOrdering(new List<List<long>>
        {
            new() { 1, 2 }
        });
    }

    [Test]
    public void GetConsecutiveDigitsOfLength_ThreeElementsAndLengthTwo_ShouldReturnTwoListsWithTwoElements()
    {
        var digitTuples = new List<long> { 1, 2, 3 }.GetConsecutiveDigitsOfLength(2);

        digitTuples.Should().BeEquivalentToWithStrictOrdering(new List<List<long>>
        {
            new() { 1, 2 },
            new() { 2, 3 }
        });
    }
}