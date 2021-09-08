/*
 * @lc app=leetcode.cn id=45 lang=csharp
 *
 * [45] 跳跃游戏 II
 */

// @lc code=start
public class Solution
{
    public int Jump(int[] nums)
    {
        // // solution 1: dp
        // // dp[i]: for nums[0...i], the minimal steps to get nums[i]
        // // if dp[i] == int.MaxValue, it is not reachable
        // int[] dp = new int[nums.Length];
        // Array.Fill(dp, int.MaxValue);
        // dp[0] = 0;
        // for (int i = 1; i < nums.Length; i++)
        // {
        //     for (int j = 0; j < i; j++)
        //     {
        //         if (dp[j] != int.MaxValue && nums[j] >= i - j)
        //             dp[i] = Math.Min(dp[i], dp[j] + 1);
        //     }
        // }
        // return dp[dp.Length - 1];

        // solution 2: greedy
        int farest = 0;
        int end = 0;
        int jumps = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            farest = Math.Max(farest, i + nums[i]);
            if (i == end)
            {
                jumps++;
                end = farest;
            }
        }
        return jumps;
    }
}
// @lc code=end

