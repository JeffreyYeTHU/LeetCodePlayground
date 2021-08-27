/*
 * @lc app=leetcode.cn id=283 lang=csharp
 *
 * [283] 移动零
 */

// @lc code=start
public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        int n = nums.Length;
        if (n == 0) return;
        int slow = 0;
        int fast = 0;
        while (fast < n)
        {
            while (slow < n && nums[slow] != 0)
                slow++;
            fast = slow + 1;
            while (fast < n && nums[fast] == 0)
                fast++;
            if (fast < n)
            {
                nums[slow] = nums[fast];
                nums[fast] = 0;
            }
        }
    }
}
// @lc code=end

