/*
 * @lc app=leetcode.cn id=48 lang=csharp
 *
 * [48] 旋转图像
 */

// @lc code=start
public class Solution
{
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < (n + 1) / 2; j++)
            {
                int row = i;
                int col = j;
                int temp = matrix[row][col];
                for (int k = 0; k < 3; k++)
                {
                    matrix[row][col] = matrix[n - 1 - col][row];
                    int t = row;
                    row = n - 1 - col;
                    col = t;
                }
                matrix[row][col] = temp;
            }
        }
    }
}
// @lc code=end

