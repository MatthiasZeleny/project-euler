namespace Problems._002X;

public class Problem0024 : IEulerProblem<long>
{
    public long Example() => GetNthElementOfLexicographicOrderOfDigitsUpTill(4, 2);

    public long Solution() => 0;

    private static long GetNthElementOfLexicographicOrderOfDigitsUpTill(int position, int highestDigit) =>
        GetLexicographicOrderedUpTo(highestDigit)[position - 1];

    private static List<long> GetLexicographicOrderedUpTo(int highestDigit) =>
        new() { 012, 021, 102, 120, 201, 210 };
}
