using Numbers;

namespace Problems._001X;

public class Problem0017 : IEulerProblem<long>
{
    public long Example() => CountLettersUpTo(5);

    public long Solution() => 0;

    private static int CountLettersUpTo(int highestNumber) =>
        CreateWordListUpTo(highestNumber).Select(word => word.Length).Sum();

    private static IEnumerable<string> CreateWordListUpTo(int highestNumber) =>
        NumberList
            .NumbersUpTo(highestNumber)
            .Select(Words.ToWord);
}
