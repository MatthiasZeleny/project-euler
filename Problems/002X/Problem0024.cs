using Numbers.Structures;

namespace Problems._002X;

public class Problem0024 : IEulerProblem<long>
{
    public long Example() => GetNthElementOfLexicographicOrderOfDigitsUpTill(4, 2);

    public long Solution() => 0;

    private static long GetNthElementOfLexicographicOrderOfDigitsUpTill(int position, int highestDigit) =>
        LexicographicNumbers.GetLexicographicOrderedUpTo(highestDigit)[position - 1];

}
