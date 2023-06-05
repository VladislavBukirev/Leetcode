using NUnit.Framework;

public class SubarraySumEqualsK
{
    public int SubarraySum(int[] nums, int k)
    {
        var ans = 0;
        var sum = 0;
        var dict = new Dictionary<int, int> { [0] = 1 };
        foreach (var t in nums)
        {
            sum += t;
            if (dict.ContainsKey(sum - k))
                ans += dict[sum - k];
            if (dict.ContainsKey(sum))
                dict[sum]++;
            else dict[sum] = 1;
        }

        return ans;
    }
}

public class SubarraySumEqualsKTests
{
    [Test]
    public void TestSubarraySumEqualsK()
    {
        var instance = new SubarraySumEqualsK();
        Assert.AreEqual(2, instance.SubarraySum(new[] { 1, 1, 1, }, 2));
        Assert.AreEqual(2, instance.SubarraySum(new[] { 1, 2, 3 }, 3));
        Assert.AreEqual(2, instance.SubarraySum(new[] { 1, 1, 1, 1, 2, 3 }, 4));
        Assert.AreEqual(3, instance.SubarraySum(new[] { 1, 2, 3, 1, 5, 7, 0, 0 }, 6));
        Assert.AreEqual(4, instance.SubarraySum(new[] { 1, 2, 3, 1, 5, 7, 0, 0 }, 7));
        Assert.AreEqual(1, instance.SubarraySum(new[] { -1, -1, 1 }, 0));
    }
}