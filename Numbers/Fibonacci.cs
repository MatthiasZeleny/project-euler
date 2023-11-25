using System.Collections;

namespace Numbers;

public static class Fibonacci
{
    public static IEnumerable<long> GetAllLessOrEqual(long threshold)
    {
        var fibonacciProvider = new FibonacciProvider(threshold);

        return fibonacciProvider;
    }

    private class FibonacciProvider : IEnumerable<long>
    {
        private readonly long _threshold;
        private int _current = 1;
        private int _previous = 1;

        public FibonacciProvider(long threshold)
        {
            _threshold = threshold;
        }

        public IEnumerator<long> GetEnumerator()
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
            var next = _previous + _current;
            _previous = _current;
            _current = next;
        }

        private int GetCurrent() => _current;

        private bool StillNotAboveThreshold() => _current <= _threshold;
    }
}