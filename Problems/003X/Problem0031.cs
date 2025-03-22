namespace Problems._003X;

public class Problem0031 : IEulerProblem<int>
{
    public int Example() => new List<List<int>>
    {
        new() { 1, 1 },
        new() { 2 }
    }.Count;

    public int Solution() => 0;
}
