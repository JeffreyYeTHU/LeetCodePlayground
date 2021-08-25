/*
 * @lc app=leetcode.cn id=37 lang=csharp
 *
 * [37] 解数独
 */

// @lc code=start
public class Solution
{
    public void SolveSudoku(char[][] board)
    {
        Backtrack(board, 0, 0);
    }

    bool Backtrack(char[][] board, int i, int j)
    {
        if (j >= 9)
            return Backtrack(board, i + 1, 0);
        if (i >= 9)
            return true;

        if (board[i][j] != '.')
            return Backtrack(board, i, j + 1);

        for (char c = '1'; c <= '9'; c++)
        {
            if (IsValid(board, i, j, c))
            {
                // make choice
                board[i][j] = c;
                if (Backtrack(board, i, j + 1))
                    return true;

                // undo choice
                board[i][j] = '.';
            }
        }

        return false;
    }

    bool IsValid(char[][] board, int row, int col, char c)
    {
        int corRow = (row / 3) * 3;
        int corCol = (col / 3) * 3;
        for (int i = 0; i < 9; i++)
        {
            if (board[row][i] == c)
                return false;
            if (board[i][col] == c)
                return false;
            if (board[corRow + i / 3][corCol + i % 3] == c)
                return false;
        }

        return true;
    }
}
// @lc code=end

