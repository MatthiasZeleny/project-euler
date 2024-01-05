namespace Numbers;

public static class CollatzSequence
{
    public static IEnumerable<long> GetSequenceStartingWith(long start)
    {
        var current = start;

        while (current != 1)
        {
            yield return current;

            if (current.IsEven())
            {
                current /= 2;
            }
            else
            {
                current = 3 * current + 1;
            }
        }

        yield return 1;
    }
}
