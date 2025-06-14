namespace Utils;

public class Permutations(ISet<int> hashSet)
{

    public IEnumerable<IReadOnlyCollection<int>> GetAsVolatile()
    {
        if (hashSet.Count == 0)
        {
            yield break;
        }

        var array = hashSet.ToArray();

        yield return array;

        if (array.Length == 1)
        {
            yield break;
        }

        var tempOne = array[0];
        var tempTwo = array[1];

        array[1] = tempOne;
        array[0] = tempTwo;

        yield return array;
    }
}
