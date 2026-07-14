using DemosGithub;

namespace DemosGithub.Tests;

public class StringHelperTests
{
    // Reverse
    [Theory]
    [InlineData("hello", "olleh")]
    [InlineData("", "")]
    [InlineData("a", "a")]
    [InlineData("abcd", "dcba")]
    public void Reverse_ReturnsReversedString(string input, string expected)
    {
        var result = StringHelper.Reverse(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Reverse_NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => StringHelper.Reverse(null!));
    }

    // IsPalindrome
    [Theory]
    [InlineData("racecar", true)]
    [InlineData("Madam", true)]
    [InlineData("hello", false)]
    [InlineData("", true)]
    [InlineData("a", true)]
    public void IsPalindrome_ReturnsCorrectResult(string input, bool expected)
    {
        var result = StringHelper.IsPalindrome(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void IsPalindrome_NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => StringHelper.IsPalindrome(null!));
    }

    // CountOccurrences
    [Theory]
    [InlineData("banana", 'a', 3)]
    [InlineData("hello", 'z', 0)]
    [InlineData("", 'a', 0)]
    [InlineData("aaa", 'a', 3)]
    public void CountOccurrences_ReturnsCorrectCount(string input, char character, int expected)
    {
        var result = StringHelper.CountOccurrences(input, character);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CountOccurrences_NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => StringHelper.CountOccurrences(null!, 'a'));
    }

    // Truncate
    [Theory]
    [InlineData("Hello, World!", 5, "Hello...")]
    [InlineData("Hi", 10, "Hi")]
    [InlineData("Hello", 5, "Hello")]
    [InlineData("", 3, "")]
    public void Truncate_ReturnsCorrectResult(string input, int maxLength, string expected)
    {
        var result = StringHelper.Truncate(input, maxLength);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Truncate_NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => StringHelper.Truncate(null!, 5));
    }

    [Fact]
    public void Truncate_NegativeMaxLength_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => StringHelper.Truncate("hello", -1));
    }

    // ToTitleCase
    [Theory]
    [InlineData("hello world", "Hello World")]
    [InlineData("the quick brown fox", "The Quick Brown Fox")]
    [InlineData("", "")]
    [InlineData("single", "Single")]
    [InlineData("ALREADY UPPER", "Already Upper")]
    public void ToTitleCase_ReturnsCorrectResult(string input, string expected)
    {
        var result = StringHelper.ToTitleCase(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToTitleCase_NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => StringHelper.ToTitleCase(null!));
    }
}
