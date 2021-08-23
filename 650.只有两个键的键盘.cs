/*
 * @lc app=leetcode.cn id=650 lang=csharp
 *
 * [650] 只有两个键的键盘
 */

// @lc code=start
public class Solution
{
    public int MinSteps(int n)
    {
        if (n <= 1) return 0;
        int[] dp = new int[n + 1];  // dp[i] = to get i number of A, the minmal steps
        for (int i = 2; i <= n; i++)
            dp[i] = n;
        for (int i = 2; i <= n; i++)
        {
            for (int j = 1; j < i; j++)
            {
                if (Possible(j, i))
                    dp[i] = Math.Min(dp[i], dp[j] + 1 + (i - j) / j);
            }
        }
        return dp[n];
    }

    // copy at form, then only do copy
    bool Possible(int from, int to)
    {
        int dis = to - from;
        return dis >= from && dis % from == 0;
    }
}
// @lc code=end

