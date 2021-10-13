/*
 * @lc app=leetcode.cn id=54 lang=csharp
 *
 * [54] 螺旋矩阵
 */

// @lc code=start
public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var res = new List<int>();
        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);
        int large = Math.Max(m, n);
        int row = 0;
        int col = 0;
        for (int cnt = 0; cnt < (large + 1) / 2; cnt++)
        {
            // right
            for (; col < n; col++)
            {
                if (matrix[row][col] == int.MaxValue)
                    break;
                res.Add(matrix[row][col]);
                matrix[row][col] = int.MaxValue;
            }
            col--;
            row++;
            // down
            for (; row < m; row++)
            {
                if (matrix[row][col] == int.MaxValue)
                    break;
                res.Add(matrix[row][col]);
                matrix[row][col] = int.MaxValue;
            }
            row--;
            col--;
            // left
            for (; col >= 0; col--)
            {
                if (matrix[row][col] == int.MaxValue)
                    break;
                res.Add(matrix[row][col]);
                matrix[row][col] = int.MaxValue;
            }
            col++;
            row--;
            // up
            for (; row >= 0; row--)
            {
                if (matrix[row][col] == int.MaxValue)
                    break;
                res.Add(matrix[row][col]);
                matrix[row][col] = int.MaxValue;
            }
            row++;
            col++;
        }
        return res;
    }
}
// @lc code=end

