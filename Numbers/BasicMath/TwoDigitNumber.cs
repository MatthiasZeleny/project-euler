namespace Numbers.BasicMath;

public class TwoDigitNumber(int tenDigit, int oneDigit)
{
    public int TenDigit { get; } = tenDigit;
    public int OneDigit { get; } = oneDigit;

    public long AsNumber { get; } = tenDigit * 10 + oneDigit;
}