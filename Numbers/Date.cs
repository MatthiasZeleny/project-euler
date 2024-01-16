namespace Numbers;

public class Date
{
    public long Year { get; }
    public Month Month { get; }
    public int DayInMonth { get; }
    public DayOfWeek DayOfWeek { get; }

    private Date(long year, Month month, int dayInMonth, DayOfWeek dayOfWeek)
    {
        Year = year;
        Month = month;
        DayInMonth = dayInMonth;
        DayOfWeek = dayOfWeek;
    }

    private static Date GetFirstDayOf1900() => new(1900, Month.January, 1, DayOfWeek.Monday);

    public static IEnumerable<Date> GetDaysStartingFromFirstDayOf1900()
    {
        var day = GetFirstDayOf1900();

        while (true)
        {
            yield return day;

            day = day.GetNext();
        }
        // ReSharper disable once IteratorNeverReturns
    }

    private Date GetNext()
    {
        var isLastDayInMonth = IsLastDayInMonth();

        return new Date(
            isLastDayInMonth && Month == Month.December ? Year + 1 : Year,
            isLastDayInMonth ? GetNextMonth() : Month,
            isLastDayInMonth ? 1 : DayInMonth + 1,
            GetNextDayOfWeek());
    }

    private Month GetNextMonth() =>
        Month switch
        {
            Month.January => Month.February,
            Month.February => Month.March,
            Month.March => Month.April,
            Month.April => Month.May,
            Month.May => Month.June,
            Month.June => Month.July,
            Month.July => Month.August,
            Month.August => Month.September,
            Month.September => Month.October,
            Month.October => Month.November,
            Month.November => Month.December,
            Month.December => Month.January,
            _ => throw new ArgumentOutOfRangeException()
        };

    private bool IsLastDayInMonth() => DayInMonth == GetLastDayInMonth();

    private int GetLastDayInMonth()
    {
        return Month switch
        {
            Month.January => 31,
            Month.February => IsLeapYear() ? 29 : 28,
            Month.March => 31,
            Month.April => 30,
            Month.May => 31,
            Month.June => 30,
            Month.July => 31,
            Month.August => 31,
            Month.September => 30,
            Month.October => 31,
            Month.November => 30,
            Month.December => 31,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private bool IsLeapYear() =>
        Year.IsDivisibleBy(4)
        && (Year.IsDivisibleBy(100) is false || Year.IsDivisibleBy(400));

    private DayOfWeek GetNextDayOfWeek()
    {
        return DayOfWeek switch
        {
            DayOfWeek.Sunday => DayOfWeek.Monday,
            DayOfWeek.Monday => DayOfWeek.Tuesday,
            DayOfWeek.Tuesday => DayOfWeek.Wednesday,
            DayOfWeek.Wednesday => DayOfWeek.Thursday,
            DayOfWeek.Thursday => DayOfWeek.Friday,
            DayOfWeek.Friday => DayOfWeek.Saturday,
            DayOfWeek.Saturday => DayOfWeek.Sunday,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
