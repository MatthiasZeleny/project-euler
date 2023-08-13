using Numbers;

namespace Problems;

public class Problem0009 : IEulerProblem
{
    public long Example() => GetProductOfPythagoreanTripletWithSum(3 + 4 + 5);

    private static long GetProductOfPythagoreanTripletWithSum(int sum)
    {
        var (a, b, c) = PythagoreanTriplets.CreateTripledWithSum(sum);

        return a * b * c;
    }

    public long Solution() => 0;
}