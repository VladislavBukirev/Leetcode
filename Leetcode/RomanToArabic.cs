using NUnit.Framework;

public class RomanToArabicTask
{
    public static int RomanToInt(string s)
    {
        var result = 0;
        var repDigits = new List<int>();
        for (var i = 0; i < s.Length - 1; i++)
        {
            var curr = ConvertRomanToInt(s[i]);
            var next = ConvertRomanToInt(s[i + 1]);
            if (curr > next)
            {
                repDigits.Add(curr);
                result += repDigits.Sum();
                repDigits = new List<int>();
                continue;
            }

            if (curr == next)
            {
                repDigits.Add(curr);
                continue;
            }

            if (curr < next)
            {
                repDigits.Add(curr);
                result -= repDigits.Sum();
                repDigits = new List<int>();
            }
        }

        result += repDigits.Sum() + ConvertRomanToInt(s[^1]);
        return result;
    }

    private static int ConvertRomanToInt(char romanSymbol)
    {
        var numbersDict = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };
        return numbersDict[romanSymbol];
    }
}

public class RomanToArabicTests
{
    [Test]
    public void TestRomanToInt()
    {
        Assert.AreEqual(3, RomanToArabicTask.RomanToInt("III"));
        Assert.AreEqual(13, RomanToArabicTask.RomanToInt("XIII"));
        Assert.AreEqual(39, RomanToArabicTask.RomanToInt("XXXIX"));
        Assert.AreEqual(58, RomanToArabicTask.RomanToInt("LVIII")); 
        Assert.AreEqual(59, RomanToArabicTask.RomanToInt("LIX")); 
        Assert.AreEqual(64, RomanToArabicTask.RomanToInt("LXIV"));
        Assert.AreEqual(69, RomanToArabicTask.RomanToInt("LXIX"));
        Assert.AreEqual(1994, RomanToArabicTask.RomanToInt("MCMXCIV"));
    }
}