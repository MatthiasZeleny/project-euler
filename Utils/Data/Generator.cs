namespace Utils.Data;

public class Generator(string first, Func<string, string> step)
{
    public IEnumerable<string> CreateEnumerable()
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
