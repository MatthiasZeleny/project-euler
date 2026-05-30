namespace Numbers.BasicMath;

public class TwoDigitNumber(BaseTenDigit tenDigit, BaseTenDigit oneDigit)
{
    public BaseTenDigit TenDigit { get; } = tenDigit;
    public BaseTenDigit OneDigit { get; } = oneDigit;

    public long AsNumber { get; } = tenDigit.AsNumber() * 10 + oneDigit.AsNumber();
}