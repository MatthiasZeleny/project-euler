using Numbers;

namespace Problems;

public class Problem0014 : IEulerProblem<int>
{
    public int Example() => CollatzSequence.GetSequenceStartingWith(13).Count();

    public int Solution() => 0;
}