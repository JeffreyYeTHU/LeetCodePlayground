/*
 * @lc app=leetcode.cn id=871 lang=csharp
 *
 * [871] 最低加油次数
 */

// @lc code=start
public class Solution
{
    public int MinRefuelStops(int target, int startFuel, int[][] stations)
    {
        // dp[i]: stop for gas i times, the max distance can go
        int n = stations.Length;
        int[] dp = new int[n + 1];
        dp[0] = startFuel;
        for (int i = 0; i < n; i++)
        {
            for (int t = i; t >= 0; t--)
            {
                if (dp[t] >= stations[i][0])
                    dp[t + 1] = Math.Max(dp[t + 1], dp[t] + stations[i][1]);
            }
        }

        // find ans
        for (int i = 0; i <= n; i++)
        {
            if (dp[i] >= target)
                return i;
        }
        return -1;
    }

}
// @lc code=end

