namespace Numbers;

public static class Digits
{
    public static List<long> ToDigitList(this string line)
    {
        return line.ToList().Select(digit => long.Parse(digit.ToString())).ToList();
    }

    public static List<List<long>> GetConsecutiveDigitsOfLength(IReadOnlyCollection<long> digits, int length)
    {
        if (length == 2)
        {
            return new List<List<long>> { digits.ToList() };
        }

        return digits.Select(digit => new List<long> { digit }).ToList();
    }
}