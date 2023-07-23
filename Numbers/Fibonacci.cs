using System.Collections;

namespace Numbers;

public static class Fibonacci
{
    public static IEnumerable<int> GetAllLessOrEqual(int threshold)
    {
        var fibonacciProvider = new FibonacciProvider(threshold);

        return fibonacciProvider;
    }

    private class FibonacciProvider : IEnumerable<int>
    {
        private readonly int _threshold;
        private int _current = 1;
        private int _previous = 1;

        public FibonacciProvider(int threshold)
        {
            _threshold = threshold;
        }

        public IEnumerator<int> GetEnumerator()
        {
            while (StillNotAboveThreshold())
            {
                yield return GetCurrent();
                ComputeNext();
            }
        }

        private void ComputeNext()
        {
            var next = _previous + _current;
            _previous = _current;
            _current = next;
        }

        private int GetCurrent() => _current;

        private bool StillNotAboveThreshold() => _current <= _threshold;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}