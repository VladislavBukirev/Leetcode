using System.Text;
using NUnit.Framework;

public static class LongestSubstringWithoutRepeatingCharacters
{
    public static int GetLengthLongestSubstring(string s)
    {
        var test = "";
        var maxLength = -1;

        if (s.Length == 0)
            return 0;
        foreach (var c in s)
        {
            var current = c+"";
            if (test.Contains(current))
                test = test.Substring(test.IndexOf(current) + 1);
            test += c;
            maxLength = Math.Max(test.Length,maxLength);
        }
        return maxLength;
    }
}

public class LongestSubstringWithoutRepeatingCharactersTest
{
    [Test]
    public void TestLongestSubstringWithoutRepeatingCharacters()
    {
        Assert.AreEqual(3, LongestSubstringWithoutRepeatingCharacters.GetLengthLongestSubstring("abcabcbb"));
        Assert.AreEqual(1, LongestSubstringWithoutRepeatingCharacters.GetLengthLongestSubstring("bbbbb"));
        Assert.AreEqual(3, LongestSubstringWithoutRepeatingCharacters.GetLengthLongestSubstring("pwwkew"));
    }
}