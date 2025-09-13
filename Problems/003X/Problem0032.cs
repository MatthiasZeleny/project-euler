using Numbers.BasicMath;
using Utils;

namespace Problems._003X;

/// <summary>
/// <a href="https://projecteuler.net/problem=32"/>
/// </summary>
public class Problem0032 : IEulerProblem<int>
{
    public int Example() => GetSumOfPandigitalProducts(product => product == 7254);

    public int Solution() => GetSumOfPandigitalProducts(_ => true);

    private static int GetSumOfPandigitalProducts(Func<int, bool> filter)
    {
        var permutations = GetAllPermutationsFromOneToNine();

        var potentialCandidates = GetPotentialCandidates(permutations);

        var pandigitalCandidates = potentialCandidates.Where(IsValidProduct);

        var distinctResults = pandigitalCandidates.Select(candidate => candidate.Product).Distinct();

        var allowedResults = distinctResults.Where(filter);

        return allowedResults.Sum();
    }

    private static IEnumerable<IReadOnlyCollection<int>> GetAllPermutationsFromOneToNine()
        => new Permutations(Digits.DecimalDigits).GetAsVolatile();

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