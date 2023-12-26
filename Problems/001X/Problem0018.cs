using Numbers;

namespace Problems._001X;

public class Problem0018 : IEulerProblem<long>
{
    public long Example() => Triangle.FromString("3\n7 4\n2 4 6\n8 5 9 3").ComputeBiggestPath();

    public long Solution() => 0;
}
