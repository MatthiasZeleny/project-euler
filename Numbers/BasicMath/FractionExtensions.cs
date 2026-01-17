namespace Numbers.BasicMath;

public static class FractionExtensions
{
    private static readonly Fraction NeutralFraction = new(1, 1);

    public static Fraction Product(this IEnumerable<Fraction> fractions)
    {
        var product = fractions
            .Aggregate(
                NeutralFraction,
                (product, factor) =>
                    product * factor);

        return product;
    }
}