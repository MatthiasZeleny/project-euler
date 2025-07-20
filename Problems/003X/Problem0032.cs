using Utils;

namespace Problems._003X;

public class Problem0032 : IEulerProblem<int>
{
    public int Example()
    {
        var permutations = new Permutations(new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

        var list = new List<int> { 3, 9, 1, 8, 6, 7, 2, 5, 4 };
        var hit = permutations.GetAsVolatile().Where(ints => ints.SequenceEqual(list)).Select(ints => ints.ToList()).Single();

        var potentialCandidates = hit.GetEverySplit().SelectMany(parts => parts.Second.GetEverySplit().Select(secondSplit =>
            (Multiplicand: DigitsToNumber(parts.First), Multiplier: DigitsToNumber(secondSplit.First),
                Product: DigitsToNumber(secondSplit.Second))));

        var candidates = potentialCandidates
            .Where(candidate => candidate.Multiplicand * candidate.Multiplier == candidate.Product).ToList();

        return candidates.Select(candidate => candidate.Product).Sum();
    }

    private static int DigitsToNumber(IEnumerable<int> digits) => digits.Aggregate(0, (current, nextDigit) => current * 10 + nextDigit);

    public int Solution() => 0;

}
