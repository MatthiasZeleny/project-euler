namespace Utils.Data;

public class Generator<T>(T first, Func<T, T> step)
{
    public IEnumerable<T> CreateEnumerable()
    {
        var current = first;

        yield return current;

        while (true)
        {
            current = step(current);

            yield return current;
        }

        // ReSharper disable once IteratorNeverReturns
    }
}