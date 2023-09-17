using Numbers;

namespace Problems;

public class Problem0014 : IEulerProblem<long>
{
    public long Example() => CollatzSequence.GetSequenceStartingWith(13).Count();

    public long Solution() => 0;
}