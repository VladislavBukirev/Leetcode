public class FindMedianSortedArraysTask
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var mergedArray = nums1.Concat(nums2).ToList();
        mergedArray.Sort();
        return mergedArray.Count % 2 == 0
            ? (mergedArray[mergedArray.Count / 2 - 1] + mergedArray[mergedArray.Count / 2]) / 2.0
            : mergedArray[mergedArray.Count / 2];
    }
}