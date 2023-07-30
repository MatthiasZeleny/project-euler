using Numbers;

namespace Problems;

public class Problem0006 : IEulerProblem
{
    public long Example()
    {
        var numbers = NumberList.NumbersUpTo(10).ToList();

        var sumOfSquared = numbers.Select(number => number.Squared()).Sum();
        var squaredOfSum = numbers.Sum().Squared();

        return squaredOfSum - sumOfSquared;
    }

    public long Solution() => 0;
}