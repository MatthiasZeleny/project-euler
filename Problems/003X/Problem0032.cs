namespace Problems._003X;

public class Problem0032 : IEulerProblem<int>
{
    public int Example()
    {
        var products = new HashSet<int>
        {
            7254
        };

        return products.ToList().Sum();
    }

    public int Solution() => 0;
}
