using Utils;

namespace Problems._002X;

public class Problem0022 : IEulerProblem<long>
{
    public long Example() => ComputeSumOfSortedWordListMultipliedByPosition(name => name == "COLIN");

    public long Solution() => ComputeSumOfSortedWordListMultipliedByPosition(_ => true);

    private static long ComputeSumOfSortedWordListMultipliedByPosition(Func<string, bool> filter) =>
        GetNames()
            .Then(names => names.Order())
            .Then(names => names.Select((name, index) => (Name: name, Position: index + 1)))
            .Where(tuple => filter(tuple.Name))
            .Select(GetWordValueTimesPosition)
            .Sum();

    private static IEnumerable<string> GetNames()
    {
        return File.ReadAllText(Path.Join("002X", "0022_Names.txt"))
            .Split(',')
            .Select(nameWithQuotes => nameWithQuotes.Trim('"'));
    }

    private static long GetWordValueTimesPosition((string Name, int Position) tuple) =>
        WordToSumOfPositionInAlphabet(tuple.Name) * tuple.Position;

    private static long WordToSumOfPositionInAlphabet(string word) =>
        word
            .ToList()
            .Select(CharacterToNumber)
            .Sum();

    private static long CharacterToNumber(char character) =>
        character switch
        {
            >= 'A' and <= 'Z' => (long)character - 'A' + 1,
            _ => throw new ArgumentException($"Character not valid: {{{character}}}")
        };
}
