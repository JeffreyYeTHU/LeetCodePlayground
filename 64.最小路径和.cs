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
        int[,] dp = new int[m, n];
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (i == m - 1 && j == n - 1)
                    dp[i, j] = grid[i][j];
                else
                {
                    int right = (j == n - 1) ? int.MaxValue : dp[i, j + 1];
                    int down = (i == m - 1) ? int.MaxValue : dp[i + 1, j];
                    dp[i, j] = Math.Min(right, down) + grid[i][j];
                }
            }
        }
        //Print(dp);
        return dp[0, 0];
    }

    void Print(int[,] dp)
    {
        Console.WriteLine("dp=");
        for (int i = 0; i < dp.GetLength(0); i++)
        {
            for (int j = 0; j < dp.GetLength(1); j++)
            {
                Console.Write(dp[i, j] + ", ");
            }
            Console.WriteLine();
        }
    }
}
// @lc code=end

