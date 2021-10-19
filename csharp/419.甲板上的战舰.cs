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
        this.board = board;
        m = board.Length;
        if (m == 0) return 0;
        n = board[0].Length;

        int cnt = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (board[i][j] == 'X')
                {
                    Dfs(i, j);
                    cnt++;
                }
            }
        }

        return cnt;
    }

    void Dfs(int row, int col)
    {
        if (row < 0 || col < 0 || row >= m || col >= n || board[row][col] == '.')
            return;
        board[row][col] = '.';
        Dfs(row - 1, col);
        Dfs(row + 1, col);
        Dfs(row, col + 1);
        Dfs(row, col - 1);
    }
}
// @lc code=end

