namespace Problems._002X;

public class Problem0022 : IEulerProblem<long>
{
    public long Example() => WordToSumOfPositionInAlphabet("COLIN") * 938L;

    public long Solution() => 0;

    private static long WordToSumOfPositionInAlphabet(string word) => 
        word
            .ToList()
            .Select(character => (long)character - 'A' + 1)
            .Sum();
}
