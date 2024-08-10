namespace Numbers.DataUtils;

public class CachingEnumerator(IEnumerable<long> source)
{

    public IEnumerable<long> GetElements()
    {
        return source;
    }
}
