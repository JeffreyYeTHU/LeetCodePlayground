/*
 * @lc app=leetcode.cn id=73 lang=csharp
 *
 * [73] 矩阵置零
 */

// @lc code=start
public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        // find the pos of 0
        int m = matrix.Length;
        int n = matrix[0].Length;
        var pos = new List<(int, int)>();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] == 0)
                {
                    pos.Add((i, j));
                }
            }
        }
        foreach (var p in pos)
        {
            int row = p.Item1;
            int col = p.Item2;
            for (int i = 0; i < m; i++)
                matrix[i][col] = 0;
            for (int j = 0; j < n; j++)
                matrix[row][j] = 0;
        }
    }
}
// @lc code=end

