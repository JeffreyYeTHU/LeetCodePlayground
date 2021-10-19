/*
 * @lc app=leetcode.cn id=200 lang=csharp
 *
 * [200] 岛屿数量
 */

// @lc code=start
public class Solution
{
    char[][] grid;
    int m;
    int n;
    public int NumIslands(char[][] grid)
    {
        this.m = grid.Length;
        this.n = grid[0].Length;
        this.grid = grid;
        int cnt = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == '1')
                {
                    Dfs(i, j);
                    cnt++;
                }
            }
        }
        return cnt;
    }

    // Start form grid[row][col], mark reachable 1s to be true
    void Dfs(int row, int col)
    {
        if (row < 0 || row >= m || col < 0 || col >= n || grid[row][col] == '0')
            return;

        grid[row][col] = '0';

        Dfs(row - 1, col);
        Dfs(row, col - 1);
        Dfs(row + 1, col);
        Dfs(row, col + 1);
    }
}
// @lc code=end

