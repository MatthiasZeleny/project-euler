namespace Numbers;

internal static class Digits
{
    public static List<long> StringToDigitList(string line)
    {
        return line.ToList().Select(digit => long.Parse(digit.ToString())).ToList();
    }
}