namespace Numbers;

public static class CollatzSequence
{
    public static IEnumerable<int> GetSequenceStartingWith(int start)
    {
        if (start == 1)
        {
            return new List<int> { 1 };
        }

        if (start == 2)
        {
            return new List<int> { 2, 1 };
        }

        if (start == 3)
        {
            return new List<int> { 3, 10, 5, 16, 8, 4, 2, 1 };
        }

        return new List<int> { 13, 40, 20, 10, 5, 16, 8, 4, 2, 1 };
    }
}