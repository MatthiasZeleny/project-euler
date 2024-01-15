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
    [TestCase(2, 1900, Month.January, 3, DayOfWeek.Wednesday)]
    [TestCase(3, 1900, Month.January, 4, DayOfWeek.Thursday)]
    [TestCase(4, 1900, Month.January, 5, DayOfWeek.Friday)]
    [TestCase(5, 1900, Month.January, 6, DayOfWeek.Saturday)]
    [TestCase(6, 1900, Month.January, 7, DayOfWeek.Sunday)]
    [TestCase(7, 1900, Month.January, 8, DayOfWeek.Monday)]
    [TestCase(31, 1900, Month.February, 1, DayOfWeek.Thursday)]
    public void FollowingDays_ShouldBeCorrect(int steps, int year, Month month, int dayInMonth, DayOfWeek dayOfWeek)
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
