﻿using FluentAssertions;
using Numbers.Dates;

namespace Numbers.Tests.Dates;

public class DateTests
{
    private const int NumberOfDaysInANonLeapYear = 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31 + 30 + 31;
    private const int NumberOfDaysInALeapYear = NumberOfDaysInANonLeapYear + 1;

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
    [TestCase(31 + 28, 1900, Month.March, 1, DayOfWeek.Thursday)]
    [TestCase(31 + 28 + 31, 1900, Month.April, 1, DayOfWeek.Sunday)]
    [TestCase(31 + 28 + 31 + 30, 1900, Month.May, 1, DayOfWeek.Tuesday)]
    [TestCase(31 + 28 + 31 + 30 + 31, 1900, Month.June, 1, DayOfWeek.Friday)]
    [TestCase(31 + 28 + 31 + 30 + 31 + 30, 1900, Month.July, 1, DayOfWeek.Sunday)]
    [TestCase(31 + 28 + 31 + 30 + 31 + 30 + 31, 1900, Month.August, 1, DayOfWeek.Wednesday)]
    [TestCase(31 + 28 + 31 + 30 + 31 + 30 + 31 + 31, 1900, Month.September, 1, DayOfWeek.Saturday)]
    [TestCase(31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30, 1900, Month.October, 1, DayOfWeek.Monday)]
    [TestCase(31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31, 1900, Month.November, 1, DayOfWeek.Thursday)]
    [TestCase(31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31 + 30, 1900, Month.December, 1, DayOfWeek.Saturday)]
    [TestCase(NumberOfDaysInANonLeapYear, 1901, Month.January, 1, DayOfWeek.Tuesday)]
    [TestCase(4 * NumberOfDaysInANonLeapYear + 31 + 28, 1904, Month.February, 29, DayOfWeek.Monday)]
    [TestCase(4 * NumberOfDaysInANonLeapYear + 31 + 29, 1904, Month.March, 1, DayOfWeek.Tuesday)]
    [TestCase(4 * NumberOfDaysInANonLeapYear + NumberOfDaysInALeapYear + 31 + 28, 1905, Month.March, 1, DayOfWeek.Wednesday)]
    [TestCase(
        7 * NumberOfDaysInANonLeapYear + NumberOfDaysInALeapYear + 31 + 28, 1908, Month.February, 29, DayOfWeek.Saturday)]
    [TestCase(7 * NumberOfDaysInANonLeapYear + NumberOfDaysInALeapYear + 31 + 29, 1908, Month.March, 1, DayOfWeek.Sunday)]
    [TestCase(100 * NumberOfDaysInANonLeapYear + 24 + 31 + 28, 2000, Month.February, 29, DayOfWeek.Tuesday)]
    [TestCase(100 * NumberOfDaysInANonLeapYear + 24 + 31 + 29, 2000, Month.March, 1, DayOfWeek.Wednesday)]
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
