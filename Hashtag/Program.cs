using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string input ="Hello, #World! this is a ##test to get #Hashtag tags f#rom my text do not also empty # is not allowed only allow #numbers like #2134 only letters like #ABC or #abc not abc#def";
        Console.WriteLine(string.Join(", ", GetHashtag(input)));
    }
    public static string[] GetHashtag(string text) { 
        string [] words = text.Split(' ');
        string[] allHashtags = words
                                .Where(word=>
                                        word.StartsWith("#"))
                                .ToArray();

        string pattern = @"##?\w+";
        Regex regex = new(pattern);

        return allHashtags
                    .Where(hashTag => 
                                regex.IsMatch(hashTag))
                    .Select(validHashtag => 
                                validHashtag.TrimStart('#'))
                    .ToArray();

        //List<string> result = [];
        //foreach (string word in allHashtags) {
        //    if (regex.IsMatch(word))
        //    {
        //        result.Add(word);
        //    }
        //}

        //return result.Select(validHashtag=> validHashtag.TrimStart('#')).ToArray();
    }
}