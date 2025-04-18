using Numbers.BasicMath;

namespace Problems._003X;

public class Problem0031 : IEulerProblem<int>
{
    private readonly IReadOnlyList<int> _britishCountValuesInPence = new List<int>
    {
        1, 2, 5, 10, 20, 100, 200
    };

    public int Example() => CountPossibleCoinCombinationsLeadingToExact(2);

    public int Solution() => 0;

    private int CountPossibleCoinCombinationsLeadingToExact(int targetValue)
    {
        var possibleMonoCoinCombinations = CreateMonoCoinCombinationsNotAbove(_britishCountValuesInPence, targetValue).ToList();

        var combinationsValidOrNot = CreateCombinationsValidOrNot(possibleMonoCoinCombinations);

        return combinationsValidOrNot
            .Count(sum => sum == targetValue);
    }

    private static IEnumerable<List<long>> CreateMonoCoinCombinationsNotAbove(IReadOnlyList<int> currencyValues,
        int targetValue) =>
        currencyValues
            .Select(
                value => NumberList.NumbersBetween(0, targetValue / value).Select(count => count * value).ToList());

    private static IEnumerable<long> CreateCombinationsValidOrNot(List<List<long>> possibleMonoCoinCombinations) =>
        possibleMonoCoinCombinations.Aggregate<IEnumerable<long>, IEnumerable<long>>(
            new List<long> { 0 },
            CreatePossibleCombinations);

    private static IEnumerable<long> CreatePossibleCombinations(IEnumerable<long> uniqueSums,
        IEnumerable<long> monoCoinCombinations) =>
        uniqueSums.SelectMany(
            uniqueSum =>
                monoCoinCombinations.Select(singleValueSum => uniqueSum + singleValueSum));

}
