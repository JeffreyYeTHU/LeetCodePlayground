/*
 * @lc app=leetcode.cn id=999 lang=csharp
 *
 * [999] 可以被一步捕获的棋子数
 */

// @lc code=start
public class Solution
{
    public int NumRookCaptures(char[][] board)
    {
        int m = board.Length;
        int n = board[0].Length;
        (int row, int col) = Find(board);
        int cnt = 0;

        // Option 1: just search 4 direction
        // for (int i = row - 1; i >= 0; i--)
        // {
        //     // up
        //     if (board[i][col] == 'p')
        //     {
        //         cnt++;
        //         break;
        //     }
        //     else if (board[i][col] == 'B')
        //         break;
        // }
        // for (int i = row + 1; i < m; i++)
        // {
        //     // down
        //     if (board[i][col] == 'p')
        //     {
        //         cnt++;
        //         break;
        //     }
        //     else if (board[i][col] == 'B')
        //         break;
        // }
        // for (int j = col - 1; j >= 0; j--)
        // {
        //     // left
        //     if (board[row][j] == 'p')
        //     {
        //         cnt++;
        //         break;
        //     }
        //     else if (board[row][j] == 'B')
        //         break;
        // }
        // for (int j = col + 1; j < n; j++)
        // {
        //     // right
        //     if (board[row][j] == 'p')
        //     {
        //         cnt++;
        //         break;
        //     }
        //     else if (board[row][j] == 'B')
        //         break;
        // }

        // option 2: use direction array
        int[] dx = new int[] { 0, 1, 0, -1 };
        int[] dy = new int[] { 1, 0, -1, 0 };
        for (int i = 0; i < 4; i++)
        {
            for (int step = 0; ; step++)
            {
                int x = col + step * dx[i];
                int y = row + step * dy[i];
                if (x < 0 || x >= 8 || y < 0 || y >= 8 || board[y][x] == 'B')
                    break;
                else if (board[y][x] == 'p')
                {
                    cnt++;
                    break;
                }
            }
        }
        return cnt;
    }

    (int Row, int Col) Find(char[][] board)
    {
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (board[i][j] == 'R')
                    return (i, j);
            }
        }
        return (-1, -1);
    }
}
// @lc code=end

