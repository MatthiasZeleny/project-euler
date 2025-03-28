using Numbers.BasicMath;

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

        return currencyValues
            .Select(
                value => NumberList.NumbersBetween(0, targetValue / value)).Aggregate<IEnumerable<long>, IEnumerable<long>>(
                new List<long>(),
                (uniqueSums, singleValuePossibilities) => uniqueSums.SelectMany(
                        uniqueSum =>
                            singleValuePossibilities.Select(singleValueSum => uniqueSum + singleValueSum))
                    .Where(sum => sum <= targetValue).ToList())
            .Count(sum => sum == targetValue);
    }

    public int Solution() => 0;
}
