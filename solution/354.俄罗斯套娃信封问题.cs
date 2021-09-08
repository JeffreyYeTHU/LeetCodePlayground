/*
 * @lc app=leetcode.cn id=354 lang=csharp
 *
 * [354] 俄罗斯套娃信封问题
 */

// @lc code=start
public class Solution
{
    public int MaxEnvelopes(int[][] envelopes)
    {
        var query = envelopes.Select(e => new { W = e[0], H = e[1] }).OrderBy(e => e.W).ToList();
        int[] dp = new int[envelopes.Length];
        Array.Fill(dp, 1);
        for (int i = 0; i < envelopes.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (query[j].H < query[i].H && query[j].W < query[i].W)
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
            }
        }
        return dp.Max();
    }
}
// @lc code=end

