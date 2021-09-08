using System.Globalization;
using System.Reflection.Metadata.Ecma335;
/*
 * @lc app=leetcode.cn id=704 lang=csharp
 *
 * [704] 二分查找
 */

// @lc code=start
public class Solution
{
    public int Search (int[] nums, int target)
    {
        int lo = 0;
        int hi = nums.Length - 1;
        while (lo <= hi)
        {
            int mid = lo + (hi - lo) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] > target)
            {
                hi = mid - 1;
            }
            else if (nums[mid] < target)
            {
                lo = mid + 1;
            }
        }
        return -1;
    }
}
// @lc code=end