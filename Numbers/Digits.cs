namespace Numbers;

public static class Digits
{
    public static List<long> ToDigitList(this string line)
    {
        return line.ToList().Select(digit => long.Parse(digit.ToString())).ToList();
    }

    public static List<List<long>> GetConsecutiveDigitsOfLength(this IReadOnlyCollection<long> digits, int length)
    {
        var latestStartingPosition = digits.Count - length + 1;

        return Enumerable
            .Range(0, latestStartingPosition)
            .Select(startingPosition =>
                TakeSubList(digits, startingPosition, length)
            ).ToList();
    }

    private static List<long> TakeSubList(IReadOnlyCollection<long> digits, int startingPosition, int length)
    {
        return digits.Skip(startingPosition).Take(length).ToList();
    }
}