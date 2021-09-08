/*
 * @lc app=leetcode.cn id=53 lang=csharp
 *
 * [53] 最大子序和
 */

// @lc code=start
public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        // dp[i] is the sum of MaxSubArray of num[0...i] that include nums[i];
        int[] dp = new int[nums.Length];
        Array.Copy(nums, dp, nums.Length);
        for (int i = 1; i < nums.Length; i++)
        {
            dp[i] = Math.Max(dp[i], dp[i - 1] + nums[i]);
        }
        return dp.Max();
    }
}
// @lc code=end

