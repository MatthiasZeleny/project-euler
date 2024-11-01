using Numbers.BasicMath;

namespace Problems._002X;

public class Problem0028 : IEulerProblem<long>
{
    private const int FourDirections = 4;

    public long Example() => GetSumOfCornerValuesFor5X5();

    private static long GetSumOfCornerValuesFor5X5() => CreateListOfCornerValuesForNxN(5).Sum();

    private static IEnumerable<long> CreateCornerValuesBasedOnSkips(IEnumerable<long> skips)
    {
        var counter = 1L;

        yield return counter;

        foreach (var skip in skips)
        {
            counter += skip;

            yield return counter;
        }
    }

    private static IEnumerable<long> CreateListOfCornerValuesForNxN(int gridSize)
    {
        var skips = CreateSkips(gridSize);

        return CreateCornerValuesBasedOnSkips(skips);
    }

    private static IEnumerable<long> CreateSkips(int gridSize)
    {
        var rounds = gridSize / 2;
        var skips =
            NumberList.NumbersFromZeroUpTo(rounds)
                .Select(roundNumber => roundNumber * 2)
                .SelectMany(skipSize => Enumerable.Repeat(skipSize, FourDirections));

        return skips;
    }

    public long Solution() => 0;
}
