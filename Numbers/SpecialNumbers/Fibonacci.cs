using System.Collections;
using System.Numerics;

namespace Numbers.SpecialNumbers;

public static class Fibonacci
{
    public static IEnumerable<long> GetAllLessOrEqualStartingWithOneOne(long threshold)
    {
        var fibonacciProvider = new FibonacciProvider<long>(
            0,
            1,
            (left, right) => left + right,
            current => current <= threshold
        );

        return fibonacciProvider;
    }

    public static IEnumerable<BigInteger> GetAllLessOrEqualStartingWithOneOneBigInteger()
    {
        var fibonacciProvider = new FibonacciProvider<BigInteger>(
            0,
            1,
            (left, right) => left + right,
            _ => true);

        return fibonacciProvider;
    }

    private class FibonacciProvider<TNumberType> : IEnumerable<TNumberType>
    {
        private TNumberType _previous;
        private TNumberType _current;
        private readonly Func<TNumberType, TNumberType, TNumberType> _addition;
        private readonly Func<TNumberType, bool> _keepGoing;

        internal FibonacciProvider(
            TNumberType zero,
            TNumberType one,
            Func<TNumberType, TNumberType, TNumberType> addition,
            Func<TNumberType, bool> keepGoing)
        {
            _addition = addition;
            _keepGoing = keepGoing;
            _previous = zero;
            _current = one;
        }

        public IEnumerator<TNumberType> GetEnumerator()
        {
            while (StillNotAboveThreshold())
            {
                yield return GetCurrent();
                ComputeNext();
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void ComputeNext()
        {
            var next = _addition(_previous, _current);
            _previous = _current;
            _current = next;
        }

        private TNumberType GetCurrent() => _current;

        private bool StillNotAboveThreshold() => _keepGoing(_current);
    }
}