using Numbers.BasicMath;

namespace Problems._002X;

/// <summary>
/// <a href="https://projecteuler.net/problem=28"/>
/// </summary>
public class Problem0028 : IEulerProblem<long>
{
    private const int FourDirections = 4;

    public long Example() => GetSumOfCornerValuesForNxN(5);

    public long Solution() => GetSumOfCornerValuesForNxN(1001);

    private static long GetSumOfCornerValuesForNxN(int gridSize) => CreateListOfCornerValuesForNxN(gridSize).Sum();

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

    private static IEnumerable<long> CreateSkips(int gridSize) =>
        NumberList.NaturalNumbersUpTo(gridSize)
            .Where(number => number.IsEven())
            .SelectMany(skipSize => Enumerable.Repeat(skipSize, FourDirections));

}
