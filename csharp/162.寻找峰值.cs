/*
 * @lc app=leetcode.cn id=162 lang=csharp
 *
 * [162] 寻找峰值
 */

// @lc code=start
public class Solution
{
    public int FindPeakElement(int[] nums)
    {
        // solution 1:
        // int n = nums.Length;
        // if (n == 1 || nums[0] > nums[1])
        //     return 0;
        // for (int i = 1; i < n - 1; i++)
        //     if (nums[i] > nums[i - 1] && nums[i] > nums[i + 1])
        //         return i;
        // return n - 1;

        // solution 2:
        int n = nums.Length;
        if (n == 1 || nums[0] > nums[1])
            return 0;
        else if (nums[n - 1] > nums[n - 2])
            return n - 1;
        int low = 1;
        int high = n - 2;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] > nums[mid - 1] && nums[mid] > nums[mid + 1])
            {
                return mid;
            }
            else if (nums[mid] < nums[mid + 1])
            {
                low = mid + 1;
            }
            else if (nums[mid] < nums[mid - 1])
            {
                high = mid - 1;
            }
        }
        return n - 1;
    }
}
// @lc code=end

