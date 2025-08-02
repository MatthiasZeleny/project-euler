using Numbers.BasicMath;
using Utils;

namespace Problems._003X;

public class Problem0032 : IEulerProblem<int>
{
    public int Example() => GetSumOfPandigitalProducts(product => product == 7254);

    private static int GetSumOfPandigitalProducts(Func<int, bool> allowedProducts)
    {
        var permutations = new Permutations(new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }).GetAsVolatile();

        var potentialCandidates = permutations.SelectMany(permutation => permutation.GetEverySplit()).SelectMany(parts =>
            parts.Second.GetEverySplit().Select(secondSplit =>
                (Multiplicand: parts.First.DigitsToNumber(),
                    Multiplier: secondSplit.First.DigitsToNumber(),
                    Product: secondSplit.Second.DigitsToNumber())));

        var pandigitalProduct = potentialCandidates
            .Where(candidate => candidate.Multiplicand * candidate.Multiplier == candidate.Product).ToList();

        return pandigitalProduct.Select(candidate => candidate.Product).Distinct().Where(allowedProducts).Sum();
    }

    public int Solution() => 0;

}
 
