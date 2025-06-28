using Utils;

namespace Problems._003X;

public class Problem0032 : IEulerProblem<int>
{
    public int Example()
    {
        var permutations = new Permutations(new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

        var list = new List<int> { 3, 9, 1, 8, 6, 7, 2, 5, 4 };
        var hit = permutations.GetAsVolatile().Where(ints => ints.SequenceEqual(list)).Select(ints => ints.ToList()).Single();

        var aggregate = hit.TakeLast(4).Aggregate(0, (current, nextDigit) => current * 10 + nextDigit);

        return GetSumOfProducts([aggregate]);
    }

    public int Solution() => 0;

    private static int GetSumOfProducts(HashSet<int> products) => products.ToList().Sum();
}
