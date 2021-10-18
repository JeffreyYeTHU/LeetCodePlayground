/*
 * @lc app=leetcode.cn id=153 lang=csharp
 *
 * [153] 寻找旋转排序数组中的最小值
 */

// @lc code=start
public class Solution
{
    public int FindMin(int[] nums)
    {
        // Solution 1:
        // int n = nums.Length;
        // if (nums[0] < nums[n - 1])
        //     return nums[0];
        // for (int i = 1; i < n - 1; i++)
        // {
        //     if (nums[i] < nums[i - 1] && nums[i] < nums[i + 1])
        //         return nums[i];
        // }
        // return nums[n - 1];

        // Solution 2:
        int lo = 0;
        int hi = nums.Length - 1;
        while (lo < hi)
        {
            int mid = lo + (hi - lo) / 2;
            if (nums[mid] < nums[hi])
                hi = mid;
            else if (nums[mid] > nums[hi])
                lo = mid + 1;
        }
        return nums[lo];
    }
}
// @lc code=end

