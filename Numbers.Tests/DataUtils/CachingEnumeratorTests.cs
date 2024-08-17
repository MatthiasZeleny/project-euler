using FluentAssertions;
using Numbers.DataUtils;

namespace Numbers.Tests.DataUtils;

public class CachingEnumeratorTests
{
    [Test]
    public void GetEnumerable_Once_ShouldStartWithFirstElement()
    {
        var source = new List<long>
        {
            1
        };

        var reusableEnumeratorList = new CachingEnumerator(source);

        reusableEnumeratorList.GetElements().First().Should().Be(1);
    }

    [Test]
    public void GetEnumerable_TakeMultiple_ShouldContainAll()
    {
        var source = new List<long>
        {
            1, 2
        };

        var reusableEnumeratorList = new CachingEnumerator(source);

        reusableEnumeratorList.GetElements().Take(2).ToList().Should().BeEquivalentTo([1, 2]);
    }
}
