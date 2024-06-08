using Problems._002X;

namespace Problems.Tests._002X;

public class Problem0026Tests : EulerProblemTestBase<Problem0026, int>
{
    protected override int ExampleResult => new List<int> { 0, 1, 0, 0, 1, 6, 0, 1, 0 }.Max();
    protected override int ProblemResult => 0;
}
