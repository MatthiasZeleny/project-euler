using FluentAssertions;
using JetBrains.Annotations;

namespace Problems.Tests;

[UsedImplicitly(ImplicitUseTargetFlags.WithInheritors)]
public abstract class EulerProblemTestBase<TEulerProblem, TUnit> where TEulerProblem : IEulerProblem<TUnit>, new()
{
    protected abstract TUnit ExampleResult { get; }
    protected abstract TUnit ProblemResult { get; }

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