namespace Utils;

public class Permutations(ISet<int> hashSet)
{

    public IEnumerable<IReadOnlyCollection<int>> GetAsVolatile()
    {
        if (hashSet.Count == 0)
        {
            yield break;
        }

        yield return hashSet.ToArray();
    }
}
