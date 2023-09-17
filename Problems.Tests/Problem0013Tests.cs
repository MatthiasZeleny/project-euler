using System.Globalization;
using System.Numerics;

namespace Problems.Tests;

public class Problem0013Tests : EulerProblemTestBase<Problem0013, BigInteger>
{
    protected override BigInteger ExampleResult => BigInteger.Parse("8348422521");

    protected override BigInteger ProblemResult => BigInteger.Parse("14A0DA7E6", NumberStyles.HexNumber);
}