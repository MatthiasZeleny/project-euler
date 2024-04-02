namespace Numbers.Texts;

public static class Characters
{
    public static long ToNumber(this char character) =>
        character switch
        {
            >= 'A' and <= 'Z' => (long)character - 'A' + 1,
            _ => throw new ArgumentException($"Character not valid: {{{character}}}")
        };
}
