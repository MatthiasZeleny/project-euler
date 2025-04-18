using Numbers.BasicMath;

namespace Problems._003X;

public class Problem0031 : IEulerProblem<int>
{
    private readonly IReadOnlyList<int> _currencyValues = new List<int>
    {
        1, 2, 5, 10, 20, 100, 200
    };

    public int Example() => CountPossibleCurrencyCombinationsLeadingToExact(2);

    public int Solution() => 0;

    private int CountPossibleCurrencyCombinationsLeadingToExact(int targetValue)
    {
        var possibleMonoCurrencyCombinations = CreateMonoCurrencyCombinationsBotAbove(_currencyValues, targetValue).ToList();

        var combinationsValidOrNot = CreateCombinationsValidOrNot(possibleMonoCurrencyCombinations);

        return combinationsValidOrNot
            .Count(sum => sum == targetValue);
    }

    private static IEnumerable<List<long>> CreateMonoCurrencyCombinationsBotAbove(IReadOnlyList<int> currencyValues,
        int targetValue) =>
        currencyValues
            .Select(
                value => NumberList.NumbersBetween(0, targetValue / value).Select(count => count * value).ToList());

    private static IEnumerable<long> CreateCombinationsValidOrNot(List<List<long>> possibleMonoCurrencyCombinations) =>
        possibleMonoCurrencyCombinations.Aggregate<IEnumerable<long>, IEnumerable<long>>(
            new List<long> { 0 },
            CreatePossibleCombinations);

    private static IEnumerable<long> CreatePossibleCombinations(IEnumerable<long> uniqueSums,
        IEnumerable<long> monoCurrencyCombinations) =>
        uniqueSums.SelectMany(
            uniqueSum =>
                monoCurrencyCombinations.Select(singleValueSum => uniqueSum + singleValueSum));

}
