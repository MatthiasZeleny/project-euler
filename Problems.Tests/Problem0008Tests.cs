namespace Problems.Tests;

public class Problem0008Tests : EulerProblemTestBase<Problem0008>
{
    protected override long ExampleResult => GetLargestProductInMatrixUsingNDigits(4);

    protected override long ProblemResult => 0x0;

    private static long GetLargestProductInMatrixUsingNDigits(int numberOfDigits) =>
        new List<long> { 9, 9, 8, 9 }
            .Aggregate(1L, (product, factor) => product * factor);
}