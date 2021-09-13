/*
 * @lc app=leetcode.cn id=85 lang=csharp
 *
 * [85] 最大矩形
 */

// @lc code=start
public class Solution
{
    public int MaximalRectangle(char[][] matrix)
    {
        // // solution 1:
        // int m = matrix.Length;
        // if (m == 0) return 0;
        // int n = matrix[0].Length;

        // // get the left 1 count
        // var left = new int[m, n];
        // for (int j = 0; j < n; j++)
        // {
        //     for (int i = 0; i < m; i++)
        //     {
        //         if (matrix[i][j] == '0')
        //             left[i, j] = 0;
        //         else
        //         {
        //             if (j == 0)
        //             {
        //                 left[i, j] = 1;
        //             }
        //             else
        //             {
        //                 left[i, j] = left[i, j - 1] + 1;
        //             }
        //         }
        //     }
        // }

        // // find all max rec
        // var maxRec = new int[m, n];
        // for (int i = 0; i < m; i++)
        // {
        //     for (int j = 0; j < n; j++)
        //     {
        //         int minWidth = int.MaxValue;
        //         for (int k = i; k >= 0; k--)
        //         {
        //             minWidth = Math.Min(minWidth, left[k, j]);
        //             maxRec[i, j] = Math.Max(maxRec[i, j], minWidth * (i - k + 1));
        //         }
        //     }
        // }

        // // find the max
        // int res = 0;
        // for (int i = 0; i < m; i++)
        // {
        //     for (int j = 0; j < n; j++)
        //     {
        //         res = Math.Max(res, maxRec[i, j]);
        //     }
        // }
        // return res;

        // solution 2: use stack
        int m = matrix.Length;
        if (m == 0) return 0;
        int n = matrix[0].Length;

        // get the left 1 count
        var left = new int[m, n];
        for (int j = 0; j < n; j++)
        {
            for (int i = 0; i < m; i++)
            {
                if (matrix[i][j] == '0')
                    left[i, j] = 0;
                else
                {
                    if (j == 0)
                        left[i, j] = 1;
                    else
                        left[i, j] = left[i, j - 1] + 1;
                }
            }
        }

        // use mono stack to find max
        int res = 0;
        for (int j = 0; j < n; j++)
        {
            var down = new int[m];
            var up = new int[m];
            var stk = new Stack<int>();
            for (int i = 0; i < m; i++)
            {
                while (stk.Count != 0 && left[stk.Peek(), j] >= left[i, j])
                    stk.Pop();
                down[i] = stk.Count == 0 ? -1 : stk.Peek();
                stk.Push(i);
            }
            stk.Clear();
            for (int i = m - 1; i >= 0; i--)
            {
                while (stk.Count != 0 && left[stk.Peek(), j] >= left[i, j])
                    stk.Pop();
                up[i] = stk.Count == 0 ? m : stk.Peek();
                stk.Push(i);
            }
            for (int i = 0; i < m; i++)
            {
                res = Math.Max(res, (up[i] - down[i] - 1) * left[i, j]);
            }
        }
        return res;
    }
}
// @lc code=end

