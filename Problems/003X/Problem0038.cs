using Numbers.Combinations;

namespace Problems._003X;

public class Problem0038 : IEulerProblem<long>
{
    public long Example() => new List<long> { NumberChains.Chain([192, 384, 576]) }.Max();

    public long Solution() => 0;
}