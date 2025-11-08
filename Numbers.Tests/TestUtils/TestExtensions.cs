using FluentAssertions.Collections;

namespace Numbers.Tests.TestUtils;

internal static class TestExtensions
{
    public static void BeEquivalentToWithStrictOrdering<TItemType>(
        this GenericCollectionAssertions<TItemType> genericCollectionAssertions,
        IEnumerable<TItemType> expectation) =>
        genericCollectionAssertions.BeEquivalentTo(expectation, options => options.WithStrictOrdering());
}