/*
 * @lc app=leetcode.cn id=88 lang=csharp
 *
 * [88] 合并两个有序数组
 */

// @lc code=start
public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        // shift element of nums1 to rear
        for (int p = m + n - 1; p >= n; p--)
        {
            nums1[p] = nums1[p - n];
        }

        // do copy
        for (int i = n, j = 0, k = 0; k < m + n; k++)
        {
            if (j >= n || (j < n && i < m + n && nums1[i] < nums2[j]))
            {
                nums1[k] = nums1[i];
                i++;
            }
            else
            {
                nums1[k] = nums2[j];
                j++;
            }
        }
    }
}
// @lc code=end

