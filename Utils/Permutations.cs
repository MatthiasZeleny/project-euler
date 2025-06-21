namespace Utils;

public class Permutations(ISet<int> hashSet)
{

    public IEnumerable<IReadOnlyCollection<int>> GetAsVolatile()
    {
        if (hashSet.Count == 0)
        {
            yield break;
        }

        var mutatedArray = hashSet.ToArray();
        var setSize = mutatedArray.Length;

        var controlArray = mutatedArray.Select(_ => 0).ToArray();

        yield return mutatedArray;

        var stackPointer = 1;
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
}
