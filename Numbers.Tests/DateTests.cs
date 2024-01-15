using FluentAssertions;

namespace Numbers.Tests;

public class DateTests
{
    [Test]
    public void FirstDayOf1990_ShouldBeCorrect()
    {
        var firstDayOf1900 = Date.GetDaysStartingFromFirstDayOf1900().First();

        firstDayOf1900.Year.Should().Be(1900);
        firstDayOf1900.Month.Should().Be(Month.January);
        firstDayOf1900.DayInMonth.Should().Be(1);
        firstDayOf1900.DayOfWeek.Should().Be(DayOfWeek.Monday);
    }

    [TestCase(1, 1900, Month.January, 2, DayOfWeek.Tuesday)]
    public void FollowingDays(int steps, int year, Month month, int dayInMonth, DayOfWeek dayOfWeek)
    {
        var day = Date.GetDaysStartingFromFirstDayOf1900().Skip(steps).First();

        day.Should().BeEquivalentTo(
            new
            {
                Year = year,
                Month = month,
                DayInMonth = dayInMonth,
                DayOfWeek = dayOfWeek
            });
    }
}
