using Utils.Data;

namespace Problems._003X;

/// <summary>
/// <a href="https://projecteuler.net/problem=31"/>
/// </summary>
public class Problem0031 : IEulerProblem<int>
{
    private readonly IReadOnlyList<int> _britishCountValuesInPence = new List<int>
    {
        1, 2, 5, 10, 20, 50, 100, 200
    };

    public int Example() => CountPossibleCoinCombinationsLeadingToExact(2);

    public int Solution() => CountPossibleCoinCombinationsLeadingToExact(200);

    private int CountPossibleCoinCombinationsLeadingToExact(int targetValue)
    {
        var possibleMonoCoinCombinations =
            CreateMonoCoinCombinationsNotAbove(_britishCountValuesInPence, targetValue).ToList();

        var combinationsValidOrNot = CreateCombinationsWhichAreNotTooMuch(possibleMonoCoinCombinations, targetValue);

        return combinationsValidOrNot
            .Count(sum => sum == targetValue);
    }

    private static IEnumerable<IEnumerable<long>> CreateMonoCoinCombinationsNotAbove(IReadOnlyList<int> currencyValues,
        int targetValue) =>
        currencyValues
            .Select(value => new Generator<long>(0, current => current + value).CreateEnumerable()
                .TakeWhile(sum => sum <= targetValue));

    private static IEnumerable<long> CreateCombinationsWhichAreNotTooMuch(
        List<IEnumerable<long>> possibleMonoCoinCombinations,
        int targetValue) =>
        possibleMonoCoinCombinations.Aggregate<IEnumerable<long>, IEnumerable<long>>(
            new List<long> { 0 },
            (longs, enumerable) => CreatePossibleCombinations(longs, enumerable).Where(sum => sum <= targetValue));

    private static IEnumerable<long> CreatePossibleCombinations(IEnumerable<long> uniqueSums,
        IEnumerable<long> monoCoinCombinations) =>
        uniqueSums.SelectMany(uniqueSum =>
            monoCoinCombinations.Select(singleValueSum => uniqueSum + singleValueSum));

}