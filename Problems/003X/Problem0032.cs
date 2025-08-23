using Numbers.BasicMath;
using Utils;

namespace Problems._003X;

public class Problem0032 : IEulerProblem<int>
{
    public int Example() => GetSumOfPandigitalProducts(product => product == 7254);

    public int Solution() => GetSumOfPandigitalProducts(_ => true);

    private static int GetSumOfPandigitalProducts(Func<int, bool> filter)
    {
        var permutations = GetAllPermutationsFromOneToNine();

        var potentialCandidates = GetPotentialCandidates(permutations);

        var pandigitalProduct = potentialCandidates.Where(IsValidProduct).ToList();

        var allowedProducts = pandigitalProduct.Where(product => filter(product.Product)).ToList();

        return allowedProducts.Select(candidate => candidate.Product).Distinct().Sum();
    }

    private static IEnumerable<IReadOnlyCollection<int>> GetAllPermutationsFromOneToNine() =>
        new Permutations(new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }).GetAsVolatile();

    private static bool IsValidProduct((int Multiplicand, int Multiplier, int Product) candidate) =>
        candidate.Multiplicand * candidate.Multiplier == candidate.Product;

    private static IEnumerable<(int Multiplicand, int Multiplier, int Product)> GetPotentialCandidates(
        IEnumerable<IReadOnlyCollection<int>> permutations) =>
        permutations.SelectMany(permutation => permutation.GetEverySplit()).SelectMany(parts =>
            parts.Second.GetEverySplit().Select(secondSplit =>
                (Multiplicand: parts.First.DigitsToNumber(),
                    Multiplier: secondSplit.First.DigitsToNumber(),
                    Product: secondSplit.Second.DigitsToNumber())));
}
