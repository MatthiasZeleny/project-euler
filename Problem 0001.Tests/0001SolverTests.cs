namespace Problem_0001.Tests;

public class Problem0001SolverTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Example_ShouldReturnCorrectValue()
    {
        var example = Problem0001Solver.Example();

        Assert.That(example, Is.EqualTo(23));
    }
}