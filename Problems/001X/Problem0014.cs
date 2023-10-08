using Numbers;

namespace Problems._001X;

public class Problem0014 : IEulerProblem<long>
{
    public long Example() => CollatzSequence.GetSequenceStartingWith(13).Count();

    public long Solution() => NumberList.NumbersUpTo(1_000_000).Select(number =>
        (Start: number, CountUntilOne: CollatzSequence.GetSequenceStartingWith(number).Count())).Aggregate(
        (currentLongest, nextCandidate) =>
            nextCandidate.CountUntilOne > currentLongest.CountUntilOne ? nextCandidate : currentLongest).Start;
}