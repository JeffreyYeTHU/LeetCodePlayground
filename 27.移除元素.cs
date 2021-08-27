/*
 * @lc app=leetcode.cn id=27 lang=csharp
 *
 * [27] 移除元素
 */

// @lc code=start
public class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        if (nums.Length == 0) return 0;
        int low = 0;
        int high = nums.Length - 1;
        while (low < high)
        {
            while (high > low && nums[high] == val)
                high--;
            while (low < high && nums[low] != val)
                low++;
            if (low < high)
            {
                nums[low] = nums[high];
                nums[high] = -1;
                low++;
                high--;
            }
        }
        if (nums[low] == val || nums[low] == -1)
            return low;
        else
            return low + 1;
    }
}
// @lc code=end

