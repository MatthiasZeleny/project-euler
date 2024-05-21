using System.Collections;

namespace Numbers.SpecialNumbers;

public static class Fibonacci
{
    public static IEnumerable<long> GetAllLessOrEqualStartingWithOneOne(long threshold)
    {
        var fibonacciProvider = new FibonacciProvider<long>(
            threshold,
            0,
            1,
            (left, right) => left + right,
            (left, right) => left <= right);

        return fibonacciProvider;
    }

    private class FibonacciProvider<TNumberType> : IEnumerable<TNumberType>
    {
        private readonly TNumberType _threshold;
        private TNumberType _current;
        private TNumberType _previous;
        private readonly Func<TNumberType, TNumberType, TNumberType> _addition;
        private readonly Func<TNumberType, TNumberType, bool> _leftIsSmallerOrEqual;

        public FibonacciProvider(
            TNumberType threshold,
            TNumberType zero,
            TNumberType one
            , Func<TNumberType, TNumberType, TNumberType> addition,
            Func<TNumberType, TNumberType, bool> leftIsSmallerOrEqual)
        {
            _leftIsSmallerOrEqual = leftIsSmallerOrEqual;
            _addition = addition;
            _current = one;
            _previous = zero;
            _threshold = threshold;
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

        private bool StillNotAboveThreshold() => _leftIsSmallerOrEqual(_current, _threshold);
    }
}
