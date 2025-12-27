namespace Numbers.BasicMath;

public class TwoDigitNumber(Digit tenDigit, Digit oneDigit)
{
    public Digit TenDigit { get; } = tenDigit;
    public Digit OneDigit { get; } = oneDigit;

    public long AsNumber { get; } = tenDigit.AsNumber() * 10 + oneDigit.AsNumber();
}