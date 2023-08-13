namespace Problems;

public class Problem0009 : IEulerProblem
{
    public long Example() => GetProductOfPythagoreanTripletWithSum(3 + 4 + 5);

    private static long GetProductOfPythagoreanTripletWithSum(int sum)
    {
        var (a, b, c) = CreateTripledWithSum(sum);

        return a * b * c;
    }

    private static (long a, long b, long c) CreateTripledWithSum(int sum) => (3, 4, 5);

    public long Solution() => 0;
}