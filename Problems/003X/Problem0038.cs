using Numbers.Combinations;
using Numbers.SpecialNumbers;

namespace Problems._003X;

public class Problem0038 : IEulerProblem<long>
{
    public long Example()
    {
        var exampleCombination = Enumerable.Range(1,3).Select(number => number * 192L).ToList();

        return new List<List<long>> { exampleCombination }.Select(NumberChains.Chain).Where(number=> number.IsPandigital()).Max();
    }

    public long Solution() => 0;
}