namespace Numbers;

public class Date
{
    public int Year { get; }
    public Month Month { get; }
    public int DayInMonth { get; }
    public DayOfWeek DayOfWeek { get; }

    private Date(int year, Month month, int dayInMonth, DayOfWeek dayOfWeek)
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
    }

    private Date GetNext()
    {
        var lastDayInMonth = DayInMonth == 31;

        return new Date(
            Year,
            lastDayInMonth ? Month.February : Month.January,
            lastDayInMonth ? 1 : DayInMonth + 1,
            GetNextDayOfWeek());
    }

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
