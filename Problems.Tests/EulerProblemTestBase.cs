using FluentAssertions;
using JetBrains.Annotations;

namespace Problems.Tests;

[UsedImplicitly(ImplicitUseTargetFlags.WithInheritors)]
public abstract class EulerProblemTestBase<TEulerProblem> where TEulerProblem : IEulerProblem, new()
{
    protected abstract long ExampleResult { get; }
    protected abstract long ProblemResult { get; }

    [Test]
    public void Example_ShouldReturnCorrectValue()
    {
        var example = new TEulerProblem().Example();

        example.Should().Be(ExampleResult);
    }

    [Test]
    public void Problem_ShouldReturnCorrectValue()
    {
        var solution = new TEulerProblem().Solution();

        solution.Should().Be(ProblemResult);
    }
}