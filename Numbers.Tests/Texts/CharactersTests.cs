using FluentAssertions;
using Numbers.Texts;

namespace Numbers.Tests.Texts;

public class CharactersTests
{

    [TestCase('A', 1)]
    [TestCase('Z', 26)]
    public void CharacterToNumber(char character, int expected)
    {
        var number = Characters.CharacterToNumber(character);

        number.Should().Be(expected);
    }
}
