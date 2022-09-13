namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void SplitLine_lines_become_words()
    {
        var lines = new List<string> { "dog cat mosquito", "chips soda"};
        // Act
        var words = RegExpr.SplitLine(lines);

        // Assert
        words.Should().BeEquivalentTo(new[] {"dog", "cat", "mosquito", "chips", "soda"});
    }
    
    [Fact]
    public void Resolution_try_parse()
    {
        var resolutions = new List<string> { "1920x1080", "1900x1911, 2910x4000"};
        // Act
        var parsed = RegExpr.Resolution(resolutions);

        // Assert
        parsed.Should().BeEquivalentTo(new[] {(1920, 1080), (1900, 1911), (2910, 4000)});
    }
}