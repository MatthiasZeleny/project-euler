﻿using FluentAssertions;
using Numbers.SpecialNumbers.Primes;

namespace Numbers.Tests.SpecialNumbers.Primes;

public class PrimeTests
{
    [Test]
    public void Create_First_ShouldBeTwo()
    {
        var primes = Prime.Create();

        primes.First().Should().Be(2L);
    }

    [Test]
    public void Create_TakeTen_ShouldReturnCorrectValues()
    {
        var primes = Prime.Create();

        primes.Take(10).Should().BeEquivalentTo(new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 });
    }

    [Test]
    public void Create_TakeBelowHundred_ShouldReturnCorrectValues()
    {
        var primes = Prime.Create();

        primes.TakeWhile(prime => prime < 100).Should().BeEquivalentTo(new List<int>
            { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 });
    }
}