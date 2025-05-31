namespace Problems._003X;

public class Problem0032 : IEulerProblem<int>
{
    public int Example() => GetSumOfProducts([7254]);

    public int Solution() => 0;

    private static int GetSumOfProducts(HashSet<int> products) => products.ToList().Sum();
}
