/*
 * @lc app=leetcode.cn id=26 lang=csharp
 *
 * [26] 删除有序数组中的重复项
 */

// @lc code=start
public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        int len = nums.Length;
        if (len == 0) return 0;
        int slow = 0;
        int fast = 0;
        while (fast < len)
        {
            if (nums[slow] != nums[fast])
            {
                slow++;
                nums[slow] = nums[fast];
            }
            fast++;
        }
        return slow + 1;
    }
}
// @lc code=end

