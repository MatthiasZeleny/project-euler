using System.Numerics;
using Numbers;

namespace Problems._002X;

public class Problem0020 : IEulerProblem<long>
{
    public long Example() => Enumerable.Range(1, 10 - 1).Select(number => new BigInteger(number))
        .Aggregate((product, factor) => product * factor).ToDigitList().Sum();

    public long Solution() => 0;
}
