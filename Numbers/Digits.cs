namespace Numbers;

public static class Digits
{
    public static List<long> ToDigitList(this string line)
    {
        return line.ToList().Select(digit => long.Parse(digit.ToString())).ToList();
    }

    public static List<List<long>> GetConsecutiveDigitsOfLength(IReadOnlyCollection<long> digits, int length) =>
        digits.Select(digit => new List<long> { digit }).ToList();
}