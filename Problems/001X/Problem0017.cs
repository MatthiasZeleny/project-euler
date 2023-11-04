using Numbers;

namespace Problems._001X;

public class Problem0017 : IEulerProblem<long>
{
    public long Example() =>
        CreateWordListUpUntil(5).Select(word => word.Length).Sum();

    public long Solution() => 0;

    private static IEnumerable<string> CreateWordListUpUntil(int highestNumber) =>
        NumberList
            .NumbersUpTo(highestNumber)
            .Select(Words.ToWord);
}