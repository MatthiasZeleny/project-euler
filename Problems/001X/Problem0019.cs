using Numbers;

namespace Problems._001X;

public class Problem0019 : IEulerProblem<long>
{
    public long Example() => GetCountOfFirstOfMonthSundays(1900);

    public long Solution() => 0;

    private static int GetCountOfFirstOfMonthSundays(int lastYear) =>
        Date
            .GetDaysStartingFromFirstDayOf1900()
            .TakeWhile(date => date.Year <= lastYear)
            .Count(date => date.DayOfWeek == DayOfWeek.Sunday && date.DayInMonth == 1);
}
