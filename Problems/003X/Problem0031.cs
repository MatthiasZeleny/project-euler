﻿using Numbers.BasicMath;

namespace Problems._003X;

public class Problem0031 : IEulerProblem<int>
{
    public int Example()
    {
        var targetValue = 2;

        var currencyValues = new List<int>
        {
            1, 2
        };

        var possibleMonoCurrencyCombinations = CreateMonoCurrencyCombinationsBotAbove(currencyValues, targetValue).ToList();

        var combinationsValidOrNot = CreateCombinationsValidOrNot(possibleMonoCurrencyCombinations);

        return combinationsValidOrNot
            .Count(sum => sum == targetValue);
    }

    private static IEnumerable<List<long>> CreateMonoCurrencyCombinationsBotAbove(List<int> currencyValues, int targetValue)
    {
        return currencyValues
            .Select(
                value => NumberList.NumbersBetween(0, targetValue / value).Select(count => count * value).ToList());
    }

    private static List<long> CreateCombinationsValidOrNot(List<List<long>> possibleMonoCurrencyCombinations)
    {
        return possibleMonoCurrencyCombinations.Aggregate<IEnumerable<long>, IEnumerable<long>>(
            new List<long>{0},
            (uniqueSums, monoCurrencyCombinations) => uniqueSums.SelectMany(
                    uniqueSum =>
                        monoCurrencyCombinations.Select(singleValueSum => uniqueSum + singleValueSum))
                .ToList()).ToList();
    }

    public int Solution() => 0;
}
