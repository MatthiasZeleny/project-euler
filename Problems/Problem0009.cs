using Numbers;

namespace Problems;

public class Problem0009 : IEulerProblem
{
    public long Example() => GetProductOfPythagoreanTripletWithSum(3 + 4 + 5);

    public long Solution() => GetProductOfPythagoreanTripletWithSum(1000);

    private static long GetProductOfPythagoreanTripletWithSum(int sum)
    {
        var (a, b, c) = PythagoreanTriple.CreateTripledWithSum(sum);

        return a * b * c;
    }
}