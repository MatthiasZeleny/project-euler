namespace Numbers;

public static class Words
{
    public static string ToWord(long number) =>
        number switch
        {
            1 => "one",
            2 => "two",
            3 => "three",
            4 => "four",
            5 => "five",
            _ => throw new ArgumentException("Number cannot be handled.", nameof(number))
        };
}