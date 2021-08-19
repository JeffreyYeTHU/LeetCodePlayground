/*
 * @lc app=leetcode.cn id=55 lang=csharp
 *
 * [55] 跳跃游戏
 */

// @lc code=start
public class Solution
{
    public bool CanJump(int[] nums)
    {
        // // solution 1: dp
        // // dp[i]: for nums[0...i], is nums[i] reachable?
        // bool[] dp = new bool[nums.Length];
        // Array.Fill(dp, false);
        // dp[0] = true;
        // for (int i = 1; i < nums.Length; i++)
        // {
        //     int j = i - 1;
        //     while (j >= 0)
        //     {
        //         if (dp[j] && nums[j] >= i - j)
        //         {
        //             dp[i] = true;
        //             break;
        //         }
        //         j--;
        //     }
        // }
        // return dp[dp.Length - 1];

        // Solution 2: greedy
        int farest = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            farest = Math.Max(farest, i + nums[i]);
            if (farest <= i)
                return false;
        }
        return farest >= nums.Length - 1;
    }
}
// @lc code=end

