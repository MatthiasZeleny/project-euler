namespace Problems._002X;

public class Problem0028 : IEulerProblem<long>
{
    private const int FourDirections = 4;

    public long Example() => GetSumOfCornerValuesFor5X5();

    private static int GetSumOfCornerValuesFor5X5() => CreateListOfCornerValuesFor5X5().Sum();

    private static IEnumerable<int> CreateListOfCornerValuesFor5X5()
    {
        var skips = ((List<int>) [2, 4]).SelectMany(skipSize => Enumerable.Repeat(skipSize, FourDirections));

        var counter = 1;

        yield return counter;

        foreach (var skip in skips)
        {
            counter += skip;

            yield return counter;
        }
    }

    public long Solution() => 0;
}
