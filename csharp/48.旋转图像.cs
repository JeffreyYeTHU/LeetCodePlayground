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
        int cnt = (n + 1) / 2;
        HashSet<(int, int)> hasChecked = new HashSet<(int, int)>();
        for (int i = 0; i < cnt; i++)
        {
            for (int j = 0; j < cnt; j++)
            {
                hasChecked.Add((i, j));
                if (!hasChecked.Contains((j, n - 1 - i)))
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
}
// @lc code=end

