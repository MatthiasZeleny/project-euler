using Numbers.BasicMath;

namespace Problems._003X;

/// <summary>
/// https://projecteuler.net/problem=34
/// </summary>
public class Problem0034 : IEulerProblem<long>
{
    public long Example() => new List<long> { 145 }
        .Where(number => number.ToDigitList().Select(Factorial).Sum() == number).Sum();

    public long Solution() => 0;

    private static long Factorial(long digit)
    {
        if (digit == 0) return 1;

        return digit * Factorial(digit - 1);
    }
}