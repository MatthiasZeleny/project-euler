namespace Problem_0001.Tests;

public class Problem0001Tests
{
    private const int ExampleResult = 23;
    private const int ProblemResult = 0x38ED0;

    [Test]
    public void Example_ShouldReturnCorrectValue()
    {
        var example = Problem0001.Example();

        Assert.That(example, Is.EqualTo(ExampleResult));
    }

    [Test]
    public void Problem_ShouldReturnCorrectValue()
    {
        var example = Problem0001.Solution();

        Assert.That(example, Is.EqualTo(ProblemResult));
    }
}