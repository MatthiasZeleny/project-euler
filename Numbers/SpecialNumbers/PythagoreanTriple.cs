namespace Numbers.SpecialNumbers;

public record PythagoreanTriple
{

    private PythagoreanTriple(int a, int b, int c)
    {
        A = a;
        B = b;
        C = c;
    }

    public int A { get; }
    public int B { get; }
    public int C { get; }

    public static PythagoreanTriple CreateTripledWithSum(long sum) =>
        GetTripletsUpTill(sum).First(tuple => tuple.A + tuple.B + tuple.C == sum);

    public static IEnumerable<PythagoreanTriple> GetTripletsUpTill(long highestPossibleNumber)
    {
        for (var a = 1; a <= highestPossibleNumber; a++)
        {
            for (var b = 1; b <= highestPossibleNumber; b++)
            {
                for (var c = 1; c <= highestPossibleNumber; c++)
                {
                    if (FulfillsPythagoreanTriple(a, b, c))
                    {
                        yield return Create(a, b, c);
                    }
                }
            }
        }
    }

    public static PythagoreanTriple Create(int a, int b, int c)
    {
        if (FulfillsPythagoreanTriple(a, b, c) is false)
        {
            throw new NotAPythagoreanTripleException(a, b, c);
        }

        return new PythagoreanTriple(a, b, c);
    }

    private static bool FulfillsPythagoreanTriple(int a, int b, int c)
    {
        var fulfillsEquation = a * a + b * b == c * c;
        var fulfillsInequality = a < b && b < c;

        return fulfillsEquation && fulfillsInequality;
    }

    public void Deconstruct(out int a, out int b, out int c)
    {
        a = A;
        b = B;
        c = C;
    }
}

internal class NotAPythagoreanTripleException : Exception
{
    public NotAPythagoreanTripleException(int a, int b, int c) : base($"{a},{b},{c} is not a Pythagorean triplet.")
    {
    }
}
