using NUnit.Framework;

namespace Leetcode;

public static class ValidParentheses
{
    public static bool IsValid(string s)
    {
        if (s.Length % 2 != 0 || s[0] == ')' || s[0] == ']' || s[0] == '}')
            return false;
        
        var openBrackets = new List<char> { '(', '[', '{' };

        var stack = new Stack<char>();
        foreach (var symbol in s)
        {
            if(openBrackets.Contains(symbol))
                stack.Push(symbol);
            else
            {
                if (stack.Count == 0)
                    return false;
                var openBracket = stack.Pop();
                switch (symbol)
                {
                    case ')' when openBracket != '(':
                    case ']' when openBracket != '[':
                    case '}' when openBracket != '{':
                        return false;
                }
            }
        }

        return stack.Count == 0;
    }
}

public class ValidParenthesesTest
{
    [Test]
    public void TestValidParentheses()
    {
        Assert.AreEqual(true, ValidParentheses.IsValid("()"));
        Assert.AreEqual(true, ValidParentheses.IsValid("()[]{}"));
        Assert.AreEqual(false, ValidParentheses.IsValid("("));
        Assert.AreEqual(false, ValidParentheses.IsValid("(){}}{"));
        Assert.AreEqual(false, ValidParentheses.IsValid(")"));
        Assert.AreEqual(false, ValidParentheses.IsValid("(("));
        Assert.AreEqual(false, ValidParentheses.IsValid("(]"));
        Assert.AreEqual(false, ValidParentheses.IsValid("())"));
        Assert.AreEqual(false, ValidParentheses.IsValid("(){"));
        Assert.AreEqual(false, ValidParentheses.IsValid("([)]"));
    }
}