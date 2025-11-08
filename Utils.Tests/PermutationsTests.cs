namespace Utils.Tests;

public class PermutationsTests
{
    [Test]
    public void GetAsVolatile_NoElement_ShouldReturnEmpty()
    {
        var permutations = new Permutations(new HashSet<int>());

        var list = permutations.GetAsVolatile()
            .Select(array => array.ToList()).ToList();

        list.Should().BeEquivalentTo(new List<List<int>>());
    }

    [Test]
    public void GetAsVolatile_SingleElement_ShouldReturnSingleElement()
    {
        var permutations = new Permutations(new HashSet<int> { 1 });

        var list = permutations.GetAsVolatile()
            .Select(array => array.ToList()).ToList();

        list.Should().BeEquivalentTo(
            new List<List<int>>
            {
                new()
                    { 1 }
            });
    }

    [Test]
    public void GetAsVolatile_TwoElements_ShouldReturnBothCombinations()
    {
        var permutations = new Permutations(new HashSet<int> { 1, 2 });

        var list = permutations.GetAsVolatile()
            .Select(array => array.ToList()).ToList();

        list.Should().BeEquivalentTo(
            new List<List<int>>
            {
                new() { 1, 2 },
                new() { 2, 1 }
            });
    }

    [Test]
    public void GetAsVolatile_TwoElementsAndNotCopyingTheArrays_ShouldReturnLasCombination()
    {
        var permutations = new Permutations(new HashSet<int> { 1, 2 });

        var list = permutations.GetAsVolatile()
            .Select(array => array).ToList();

        list.Should().BeEquivalentTo(
            new List<List<int>>
            {
                new() { 2, 1 },
                new() { 2, 1 }
            });
    }

    [Test]
    public void GetAsVolatile_ThreeElements_ShouldReturnBothCombinations()
    {
        var permutations = new Permutations(new HashSet<int> { 1, 2, 3 });

        var list = permutations.GetAsVolatile()
            .Select(array => array.ToList()).ToList();

        list.Should().BeEquivalentTo(
            new List<List<int>>
            {
                new() { 1, 2, 3 },
                new() { 2, 1, 3 },
                new() { 3, 1, 2 },
                new() { 1, 3, 2 },
                new() { 2, 3, 1 },
                new() { 3, 2, 1 }
            }, options => options.WithStrictOrdering());
    }

}