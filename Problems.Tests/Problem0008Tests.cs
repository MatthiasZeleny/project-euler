namespace Problems.Tests;

public class Problem0008Tests : EulerProblemTestBase<Problem0008>
{
    protected override long ExampleResult =>
        new List<long> { 9, 9, 8, 9 }
            .Aggregate(1l, (product, factor) => product * factor);

    protected override long ProblemResult => 0x0;
}