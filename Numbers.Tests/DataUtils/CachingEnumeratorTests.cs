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
}
