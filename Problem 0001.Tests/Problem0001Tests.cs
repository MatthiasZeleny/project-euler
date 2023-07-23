namespace Problem_0001.Tests;

public class Problem0001Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Example_ShouldReturnCorrectValue()
    {
        var example = Problem0001.Example();

        Assert.That(example, Is.EqualTo(23));
    }

    [Test]
    public void Problem_ShouldReturnCorrectValue()
    {
        var example = Problem0001.Solution();

        Assert.That(example, Is.EqualTo(0x38ED0));
    }
}