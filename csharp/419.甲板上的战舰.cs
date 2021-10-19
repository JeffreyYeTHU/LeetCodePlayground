/*
 * @lc app=leetcode.cn id=419 lang=csharp
 *
 * [419] 甲板上的战舰
 */

// @lc code=start
public class Solution
{
    char[][] board;
    int m;
    int n;
    public int CountBattleships(char[][] board)
    {
        // solution 1: dfs
        // this.board = board;
        // m = board.Length;
        // if (m == 0) return 0;
        // n = board[0].Length;

        // int cnt = 0;
        // for (int i = 0; i < m; i++)
        // {
        //     for (int j = 0; j < n; j++)
        //     {
        //         if (board[i][j] == 'X')
        //         {
        //             Dfs(i, j);
        //             cnt++;
        //         }
        //     }
        // }

        // return cnt;

        // solution 2: check if it is ship head: the left and upper must not be X
        int cnt = 0;
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (board[i][j] == 'X' && (i == 0 || board[i - 1][j] != 'X') && (j == 0 || board[i][j - 1] != 'X'))
                    cnt++;
            }
        }
        return cnt;
    }

    // void Dfs(int row, int col)
    // {
    //     if (row < 0 || col < 0 || row >= m || col >= n || board[row][col] == '.')
    //         return;
    //     board[row][col] = '.';
    //     Dfs(row - 1, col);
    //     Dfs(row + 1, col);
    //     Dfs(row, col + 1);
    //     Dfs(row, col - 1);
    // }
}
// @lc code=end

