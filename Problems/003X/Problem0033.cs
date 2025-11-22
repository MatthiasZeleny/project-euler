using Numbers.BasicMath;

namespace Problems._003X;

public class Problem0033 : IEulerProblem<long>
{
    public long Example() => new Fraction(98,49).Reduce().Numerator;

    public long Solution() => 0;
}