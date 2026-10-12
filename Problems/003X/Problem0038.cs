using Numbers.Combinations;

namespace Problems._003X;

public class Problem0038 : IEulerProblem<long>
{
    public long Example()
    {
        var exampleCombination = Enumerable.Range(1,3).Select(number => number * 192L).ToList();

        return new List<List<long>> { exampleCombination }.Select(NumberChains.Chain).Max();
    }

    public long Solution() => 0;
}