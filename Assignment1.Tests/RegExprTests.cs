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

    [Fact]
    public void InnerText_simple_example()
    {
        string html = "<a>hello</a>";
        string tag = "a";
        
        // Act
        var text = RegExpr.InnerText(html, tag);

        // Assert
        text.Should().BeEquivalentTo(new[] {"hello"});
    }
    
    [Fact]
    public void InnerText_no_tag()
    {
        string html = "<a>hello</a>";
        string tag = "b";
        
        // Act
        var text = RegExpr.InnerText(html, tag);

        // Assert
        text.Should().BeEmpty();
    }
    
    [Fact]
    public void InnerText_given_example()
    {
        string html = @"<div>
    <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=""https://en.wikipedia.org/wiki/Theoretical_computer_science"" title=""Theoretical computer science"">theoretical computer science</a> and <a href=""https://en.wikipedia.org/wiki/Formal_language"" title=""Formal language"">formal language</a> theory, a sequence of <a href=""https://en.wikipedia.org/wiki/Character_(computing)"" title=""Character (computing)"">characters</a> that define a <i>search <a href=""https://en.wikipedia.org/wiki/Pattern_matching"" title=""Pattern matching"">pattern</a></i>. Usually this pattern is then used by <a href=""https://en.wikipedia.org/wiki/String_searching_algorithm"" title=""String searching algorithm"">string searching algorithms</a> for ""find"" or ""find and replace"" operations on <a href=""https://en.wikipedia.org/wiki/String_(computer_science)"" title=""String (computer science)"">strings</a>.</p>
</div>";
        string tag = "a";
        // Act
        var text = RegExpr.InnerText(html, tag);

        // Assert
        text.Should().BeEquivalentTo(new[] { 
            "theoretical computer science",
            "formal language",
            "characters",
            "pattern",
            "string searching algorithms",
            "strings" });
    }
    
    [Fact]
    public void InnerText_nested_example()
    {
        string html = @"<div>
    <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>
</div>";
        string tag = "p";
        // Act
        var text = RegExpr.InnerText(html, tag);

        // Assert
        text.Should().BeEquivalentTo(new[] { 
            "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to." }
        );
    }
}