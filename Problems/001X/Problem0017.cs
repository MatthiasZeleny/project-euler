namespace Problems._001X;

public class Problem0017 : IEulerProblem<long>
{
    public long Example() =>
        new List<string> { "one", "two", "three", "four", "five" }.Select(word => word.Length).Sum();

    public long Solution() => 0;
}