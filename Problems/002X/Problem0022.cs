using Numbers.Texts;
using Utils;

namespace Problems._002X;


/// <summary>
/// <a href="https://projecteuler.net/problem=22"/>
/// </summary>
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
        tuple.Name.ToSumOfPositionsInAlphabet() * tuple.Position;

}
