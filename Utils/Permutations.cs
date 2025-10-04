namespace Utils;

public class Permutations(IReadOnlySet<int> hashSet)
{

    /// <summary>
    /// This <see cref="IEnumerable{T}"/> should not be used with <see cref="Enumerable.ToList{T}"/>.
    /// The algorithm here uses the same array in order to reduce allocations needed. This means the
    /// <see cref="Enumerable.ToList{T}"/> would be a list only containing the same last array multiple times.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<IReadOnlyCollection<int>> GetAsVolatile()
    {
        return HasNoElements() ? [] : CreatePermutations();
    }

    /// <summary>
    /// Creates a mutated array multiple times using <a href="https://en.wikipedia.org/wiki/Heap%27s_algorithm">Heap's algorithm</a>.
    /// </summary>
    /// <returns></returns>
    private IEnumerable<IReadOnlyCollection<int>> CreatePermutations()
    {
        var mutatedArray = CreateArray();

        yield return mutatedArray;


        var stackPointer = 1;
        var setSize = mutatedArray.Length;
        var controlArray = mutatedArray.Select(_ => 0).ToArray();
        while (stackPointer < setSize)
        {
            if (controlArray[stackPointer] < stackPointer)
            {
                if (stackPointer % 2 == 0)
                {
                    (mutatedArray[0], mutatedArray[stackPointer]) = (mutatedArray[stackPointer], mutatedArray[0]);
                }
                else
                {
                    (mutatedArray[controlArray[stackPointer]], mutatedArray[stackPointer]) = (mutatedArray[stackPointer],
                        mutatedArray[controlArray[stackPointer]]);
                }

                yield return mutatedArray;

                controlArray[stackPointer] += 1;
                stackPointer = 1;
            }
            else
            {
                controlArray[stackPointer] = 0;
                stackPointer += 1;
            }
        }
    }

    private int[] CreateArray() => hashSet.ToArray();

    private bool HasNoElements() => hashSet.Count == 0;
}