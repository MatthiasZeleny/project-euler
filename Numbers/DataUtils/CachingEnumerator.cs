namespace Numbers.DataUtils;

public class CachingEnumerator(IEnumerable<long> source)
{
    private readonly IEnumerator<long> _enumerator = source.GetEnumerator();
    private readonly List<long> _list = new List<long>();

    public IEnumerable<long> GetElements()
    {
        foreach (var cachedElement in _list)
        {
            yield return cachedElement;
        }

        while (_enumerator.MoveNext())
        {
            var next = _enumerator.Current;

            _list.Add(next);

            yield return next;
        }
    }
}
