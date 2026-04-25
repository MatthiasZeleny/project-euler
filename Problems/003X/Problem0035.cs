using Numbers.BasicMath;
using Numbers.SpecialNumbers.Primes;

namespace Problems._003X;

public class Problem0035 : IEulerProblem<long>
{
    public long Example()
    {
        var primeChecker = new PrimeChecker();

        return NumberList.Below(100).Select(RotatingDigits.From).Count(rotation => rotation.All(candidate=>primeChecker.IsPrime(candidate)));
    }

    public long Solution() => 0;
}