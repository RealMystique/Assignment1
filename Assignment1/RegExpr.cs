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

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
    {
        string pattern = @"((?<width>\d+)x(?<height>\d+))+";
        foreach (string line in resolutions)
        {
            foreach (Match match in Regex.Matches(line, pattern,
                         RegexOptions.None,
                         TimeSpan.FromSeconds(1)))
            {
                yield return (Int32.Parse(match.Result("${width}")), Int32.Parse(match.Result("${height}")));
            }
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag)
    {
        // adapted from https://stackoverflow.com/a/21709398
        string pattern = @"<(" + tag + @")(?:\s+[^>]+)?>(.+?)<\/\1>";
        foreach (Match match in Regex.Matches(html, pattern,
                     RegexOptions.None,
                     TimeSpan.FromSeconds(1)))
        {
            yield return Regex.Replace(match.Groups[2].Value, "<.*?>", "");
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html)
    {
        // this works for title="", but not for if there is no title at all
        //string pattern = @"<([a-zA-Z0-9]+)[^>]*?href=""(?<url>.*?)""[^>]*?title=""(?<title>.*?)""[^>]*?>(?<innertext>.+?)<\/\1>";
        // this pattern is a little more unintuitive, and could potentially be flawed due to [^t>], but that restriction is what ensures a title match, if there actually is one 
        //    this does though also mean, that throwing in another field that starts with t (that isnt title) would mean the match fails.
        string pattern = @"<([a-zA-Z0-9]+)[^>]*?href=""(?<url>.*?)""[^t>]*?(title=""(?<title>.*?)"")*[^t>]*?>(?<innertext>.+?)<\/\1>";
        
        // this is my attempt at making it recognize still even with no title=, but for some reason it doesn't work, logically it seems sound :/
        //string pattern = @"<([a-zA-Z0-9]+)[^>]*?href=""(?<url>.*?)""[^t>]*?(title=""(?<title>.*?)"")*[^>]*?>(?<innertext>.+?)<\/\1>";
        // the idea is that   title=""(?<title>.*?)""  ->  (title=""(?<title>.*?)"")*    meaning that title would match either 0 or n, but this does not work
        foreach (Match match in Regex.Matches(html, pattern,
                     RegexOptions.None,
                     TimeSpan.FromSeconds(1)))
        {
            yield return (new Uri(match.Result("${url}")),
                match.Result("${title}") != "" ? match.Result("${title}") : match.Result("${innertext}"));
        }
    }
}