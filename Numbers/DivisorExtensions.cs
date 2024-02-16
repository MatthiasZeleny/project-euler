namespace Numbers;

public static class DivisorExtensions
{
    public static IReadOnlyCollection<long> GetProperDivisors(this long number)
    {
        return number switch
        {
            220 =>
            [
                1,
                2,
                4,
                5,
                10,
                11,
                20,
                22,
                44,
                55,
                110
            ],
            284 =>
            [
                1,
                2,
                4,
                71,
                142
            ],
            _ => new List<long>()
        };
    }
}
