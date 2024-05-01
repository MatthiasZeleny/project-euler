using Numbers.BasicMath;

namespace Numbers.Structures;

public static class LexicographicNumbers
{
    public static IEnumerable<long> GetLexicographicOrderedUpTo(int highestDigit)
    {
        var startingWithOne = NumberList.NumbersUpTo(highestDigit).ToList();
        var digits = new List<long> { 0 };
        digits.AddRange(startingWithOne);

        int? maybeIndexToMove;

        do
        {
            yield return CreateNumber(digits);

            maybeIndexToMove = null;

            for (var index = 0; index < digits.Count - 1; index++)
            {
                var nextDigitIsBigger = digits[index] < digits[index + 1];

                if (nextDigitIsBigger)
                {
                    maybeIndexToMove = index;
                }
            }

            if (maybeIndexToMove is not { } indexToMove)
            {
                continue;
            }

            ReorderDigits(digits, indexToMove);
        } while (maybeIndexToMove != null);
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
