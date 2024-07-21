using Numbers.BasicMath;

namespace Numbers.Structures;

public static class LexicographicNumbers
{
    public static IEnumerable<long> GetLexicographicOrderedUpTo(int highestDigit)
    {
        var digits = CreateDigits(highestDigit);

        bool nextNumberExists;

        do
        {
            yield return CreateNumber(digits);

            nextNumberExists = TryReorderDigitsForNextDigitCombination(digits);
        } while (nextNumberExists);
    }

    private static bool TryReorderDigitsForNextDigitCombination(List<long> digits)
    {
        var candidates = digits
            .SkipLast(1)
            .Select((digit, index) => (SmallerThanNext: digit < digits[index + 1], Index: index))
            .Where(result => result.SmallerThanNext)
            .Select(result => result.Index)
            .ToList();

        var nextNumberExists = candidates.Any();

        if (nextNumberExists)
        {
            ReorderDigits(digits, candidates.Last());
        }

        return nextNumberExists;
    }

    private static List<long> CreateDigits(int highestDigit)
    {
        var startingWithOne = NumberList.NumbersFromZeroUpTo(highestDigit).ToList();
        var digits = new List<long> { 0 };
        digits.AddRange(startingWithOne);

        return digits;
    }

    private static void ReorderDigits(List<long> digits, int lastIndex)
    {
        var digitToMove = digits[lastIndex];
        var numberOfElementsBeforeDigitToMove = lastIndex;
        var tail = digits.Skip(numberOfElementsBeforeDigitToMove).ToList();

        digits.RemoveRange(numberOfElementsBeforeDigitToMove, digits.Count - numberOfElementsBeforeDigitToMove);

        var nextToReplaceDigit = tail.Where(digitCandidate => digitCandidate > digitToMove).Min();

        tail.Remove(nextToReplaceDigit);
        tail.Sort();

        digits.Add(nextToReplaceDigit);
        digits.AddRange(tail);
    }

    private static long CreateNumber(List<long> digits) => digits.Aggregate(0L, (sum, digit) => sum * 10 + digit);
}
