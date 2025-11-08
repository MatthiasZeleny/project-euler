using Numbers.BasicMath;

namespace Numbers.SpecialNumbers;

public static class CollatzSequence
{
    public static IEnumerable<long> GetSequenceStartingWith(long start)
    {
        var current = start;

        while (current != 1)
        {
            yield return current;

            current = ComputeNextElement(current);
        }

        yield return 1;
    }

    private static long ComputeNextElement(long current) => current.IsEven() ? current / 2 : 3 * current + 1;
}