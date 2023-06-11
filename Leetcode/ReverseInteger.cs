using System.Text;
using NUnit.Framework;

public class ReverseInteger 
{
    public int Reverse(int x)
    {        
        var result = 0;

        while (x != 0)
        {
            var remainder = x % 10;
            var temp = result * 10 + remainder;
            
            if ((temp - remainder) / 10 != result)
            {
                return 0;
            }

            result = temp;
            x /= 10;
        }
        
        return result;
    }
}

public class ReverseIntegerTests
{
    [Test]
    public void TestReverse()
    {
        var instance = new ReverseInteger();
        Assert.AreEqual(321, instance.Reverse(123));
        Assert.AreEqual(-321, instance.Reverse(-123));
        Assert.AreEqual(21, instance.Reverse(120));
        Assert.AreEqual(0, instance.Reverse(1534236469));
    }
}
