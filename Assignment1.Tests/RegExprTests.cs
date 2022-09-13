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
        string resolution = "1920x1080";
        // Act
        var parsed = RegExpr.Resolution(resolution);

        // Assert
        parsed.Should().BeEquivalentTo(new[] {(1920, 1080)});
    }
}