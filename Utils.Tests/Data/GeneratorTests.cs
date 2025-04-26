using Utils.Data;

namespace Utils.Tests.Data;

public class GeneratorTests
{

    [Test]
    public void First_ShouldReturnFirst()
    {
        var input = "first";
        var generator = new Generator(input, s => throw new Exception());

        var enumerable = generator.CreateEnumerable();

        enumerable.First().Should().Be(input);
    }

    [Test]
    public void Second_ShouldBeCreatedByUsingStepOnFirst()
    {
        var input = "first";
        var generator = new Generator(input, s => s + "->next");

        var enumerable = generator.CreateEnumerable();

        enumerable.Skip(1).First().Should().Be("first->next");
    }
    
    [Test]
    public void Third_ShouldBeCreatedByUsingStepOnFirstTwoTimes()
    {
        var input = "first";
        var generator = new Generator(input, s => s + "->next");

        var enumerable = generator.CreateEnumerable();

        enumerable.Skip(2).First().Should().Be("first->next->next");
    }
}
