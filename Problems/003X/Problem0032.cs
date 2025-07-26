using Numbers.BasicMath;
using Utils;

namespace Problems._003X;

public class Problem0032 : IEulerProblem<int>
{
    public int Example()
    {
        var list = new List<int> { 3, 9, 1, 8, 6, 7, 2, 5, 4 };

        return GetSumOfPandigitalProducts(ints => ints.SequenceEqual(list));
    }

    private static int GetSumOfPandigitalProducts(Func<IReadOnlyCollection<int>, bool> predicate)
    {
        var permutations = new Permutations(new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        var hit = permutations.GetAsVolatile().Where(predicate).Select(ints => ints.ToList()).Single();

        var potentialCandidates = hit.GetEverySplit().SelectMany(parts => parts.Second.GetEverySplit().Select(secondSplit =>
            (Multiplicand: parts.First.DigitsToNumber(),
                Multiplier: secondSplit.First.DigitsToNumber(),
                Product: secondSplit.Second.DigitsToNumber())));

        var pandigitalProduct = potentialCandidates
            .Where(candidate => candidate.Multiplicand * candidate.Multiplier == candidate.Product).ToList();

        return pandigitalProduct.Select(candidate => candidate.Product).Sum();
    }

    public int Solution() => 0;

}
