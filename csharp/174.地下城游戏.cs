/*
 * @lc app=leetcode.cn id=174 lang=csharp
 *
 * [174] 地下城游戏
 */

// @lc code=start
public class Solution
{
    public int CalculateMinimumHP(int[][] dungeon)
    {
        // dp[i,j] = min h from dungeon[i,j] to the last cell
        int m = dungeon.Length;
        int n = dungeon[0].Length;
        int[,] dp = new int[m, n];
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (i == m - 1 && j == n - 1)
                    dp[i, j] = Math.Max(1, 1 - dungeon[i][j]);
                else
                {
                    int right = (j == n - 1) ? int.MaxValue : dp[i, j + 1];
                    int down = (i == m - 1) ? int.MaxValue : dp[i + 1, j];
                    dp[i, j] = Math.Max(1, Math.Min(right, down) - dungeon[i][j]);
                }
            }
        }
        // Print(dp);
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

