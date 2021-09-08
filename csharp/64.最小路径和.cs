/*
 * @lc app=leetcode.cn id=64 lang=csharp
 *
 * [64] 最小路径和
 */

// @lc code=start
public class Solution
{
    public int MinPathSum(int[][] grid)
    {
        // dp[i, j] = min path sum from grid[i, j] to grid[m-1, n-1]
        int m = grid.Length;
        int n = grid[0].Length;
        int[] dp = new int[n];

        // last row
        dp[n - 1] = grid[m - 1][n - 1];
        for (int j = n - 2; j >= 0; j--)
            dp[j] = dp[j + 1] + grid[m - 1][j];

        // update
        for (int i = m - 2; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                int right = (j == n - 1) ? int.MaxValue : dp[j + 1];
                int down = dp[j];
                dp[j] = Math.Min(right, down) + grid[i][j];
            }
        }
        return dp[0];
    }
}
// @lc code=end

