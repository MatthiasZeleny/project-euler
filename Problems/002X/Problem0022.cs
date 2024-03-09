namespace Problems._002X;

public class Problem0022 : IEulerProblem<long>
{
    public long Example() => WordToSumOfPositionInAlphabet("COLIN") * 938L;

    public long Solution() => 0;

    private static long WordToSumOfPositionInAlphabet(string word) =>
        word
            .ToList()
            .Select(CharacterToNumber)
            .Sum();

    private static long CharacterToNumber(char character) => (long)character - 'A' + 1;
}
