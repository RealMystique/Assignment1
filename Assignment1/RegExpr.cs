namespace Assignment1;
using System.Text.RegularExpressions;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {
        string pattern = @"[a-zA-Z0-9]+";
        foreach (string line in lines)
        {
            foreach (Match match in Regex.Matches(line, pattern,
                         RegexOptions.None,
                         TimeSpan.FromSeconds(1)))
                yield return match.Value;
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions)
    {
        string pattern = @"((?<width>\d+)x(?<height>\d+))+";
        foreach (Match match in Regex.Matches(resolutions, pattern,
                     RegexOptions.None,
                     TimeSpan.FromSeconds(1)))
        {
            yield return ( Int32.Parse(match.Result("${width}")), Int32.Parse(match.Result("${height}")) );
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();

    public static IEnumerable<(Uri url, string title)> Urls(string html) => throw new NotImplementedException();
}