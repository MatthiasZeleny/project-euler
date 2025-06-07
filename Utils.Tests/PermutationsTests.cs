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

}
