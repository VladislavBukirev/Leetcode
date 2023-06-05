using NUnit.Framework;

public class MiniNumberOperationsTask 
{
    public int MinNumberOperations(int[] target)
    {
        var result = target[0];
        for (var i = 1; i < target.Length; i++)
            if (target[i] > target[i - 1])
                result += target[i] - target[i - 1];

        return result;
    }
}

public class SolutionTests
{
    [Test]
    public void MiniNumberOperationsTests()
    {
        var solutionInstance = new MiniNumberOperationsTask();
        var target1 = new[] { 1, 2, 3, 2, 1 };
        var res1 = solutionInstance.MinNumberOperations(target1);
        Assert.AreEqual(3, res1);
        var target2 = new[] { 3, 1, 1, 2 };
        var res2 = solutionInstance.MinNumberOperations(target2);
        Assert.AreEqual(4, res2);
        var target3 = new[] { 3, 1, 5, 4, 2 };
        var res3 = solutionInstance.MinNumberOperations(target3);
        Assert.AreEqual(7, res3);
    }
}