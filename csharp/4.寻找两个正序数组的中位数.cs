/*
 * @lc app=leetcode.cn id=4 lang=csharp
 *
 * [4] 寻找两个正序数组的中位数
 */

// @lc code=start
public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        // solution 1
        int m = nums1.Length;
        int n = nums2.Length;
        int mid = (m + n + 1) / 2;
        int cnt = 0;
        int i = -1, j = -1;
        int a = 0;
        while (cnt < mid)
        {
            if (i >= m - 1 || (i < m - 1 && j < n - 1 && nums1[i + 1] > nums2[j + 1]))
            {
                j++;
                a = nums2[j];
            }
            else
            {
                i++;
                a = nums1[i];
            }
            cnt++;
        }
        if ((m + n) % 2 == 1)
            return a;
        else
        {
            int b = Math.Min(i >= m - 1 ? int.MaxValue : nums1[i + 1], j >= n - 1 ? int.MaxValue : nums2[j + 1]);
            return (a + b) / 2.0;
        }
    }
}
// @lc code=end

