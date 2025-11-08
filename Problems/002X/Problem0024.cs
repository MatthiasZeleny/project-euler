using Numbers.Structures;

namespace Problems._002X;

/// <summary>
/// <a href="https://projecteuler.net/problem=24"/>
/// </summary>
public class Problem0024 : IEulerProblem<long>
{
    public long Example() => GetNthElementOfLexicographicOrderOfDigitsUpTill(4, 2);

    public long Solution() => GetNthElementOfLexicographicOrderOfDigitsUpTill(1_000_000, 9);

    private static long GetNthElementOfLexicographicOrderOfDigitsUpTill(int position, int highestDigit) =>
        LexicographicNumbers.GetLexicographicOrderedUpTo(highestDigit).Skip(position - 1).First();

}