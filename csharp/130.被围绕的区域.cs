/*
 * @lc app=leetcode.cn id=130 lang=csharp
 *
 * [130] 被围绕的区域
 */

// @lc code=start
public class Solution
{
    int m;
    int n;
    char[][] board;
    public void Solve(char[][] board)
    {
        m = board.Length;
        n = board[0].Length;
        this.board = board;

        // solution 1: dfs
        // mark
        for (int i = 0; i < m; i++)
        {
            Dfs(i, 0);
            Dfs(i, n - 1);
        }
        for (int j = 0; j < n; j++)
        {
            Dfs(0, j);
            Dfs(m - 1, j);
        }
        // replace
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (board[i][j] == 'M')
                    board[i][j] = 'O';
                else if (board[i][j] == 'O')
                    board[i][j] = 'X';
            }
        }
    }

    void Dfs(int row, int col)
    {
        if (row < 0 || col < 0 || row >= m || col >= n || board[row][col] != 'O')
            return;
        board[row][col] = 'M';
        Dfs(row + 1, col);
        Dfs(row - 1, col);
        Dfs(row, col + 1);
        Dfs(row, col - 1);
    }
}
// @lc code=end

