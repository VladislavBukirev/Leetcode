using NUnit.Framework;

public class TwoSumTask
{
    public static int[] TwoSum(int[] nums, int target) 
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = 0; j < nums.Length && i != j; j++)
            {
                if (nums[i] + nums[j] == target)
                    return new[] { j, i };
            }
        }

        return null;
    }
}

public class TwoSumTests
{
    [Test]
    public void TestTwoSum()
    {
        Assert.AreEqual(new[] {0, 1}, TwoSumTask.TwoSum(new[] {2, 7, 11, 15}, 9));
        Assert.AreEqual(new[] {1, 2}, TwoSumTask.TwoSum(new[] {3, 2, 4}, 6));
        Assert.AreEqual(new[] {0, 1}, TwoSumTask.TwoSum(new[] {3, 3}, 6));
        Assert.AreEqual(null, TwoSumTask.TwoSum(Array.Empty<int>(), 7));
        Assert.AreEqual(null, TwoSumTask.TwoSum(new[] {5}, 5));
        Assert.AreEqual(null, TwoSumTask.TwoSum(new[] {3, 5, 6, 7, 8}, 6));
    }
}