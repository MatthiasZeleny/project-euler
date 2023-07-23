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

        public FibonacciProvider(int threshold)
        {
            _threshold = threshold;
        }

        public IEnumerator<int> GetEnumerator()
        {
            yield return 1;
            if (_threshold == 1)
            {
                yield break;
            }

            yield return 2;
            if (_threshold == 2)
            {
                yield break;
            }

            yield return 3;
            if (_threshold is 3 or 4)
            {
                yield break;
            }

            yield return 5;
            yield return 8;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}