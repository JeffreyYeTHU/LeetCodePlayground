/*
 * @lc app=leetcode.cn id=79 lang=csharp
 *
 * [79] 单词搜索
 */

// @lc code=start
public class Solution
{
    int m, n;
    char[][] board;
    string word;
    public bool Exist(char[][] board, string word)
    {
        // find all possible start
        this.board = board;
        this.word = word;
        var start = new List<(int, int)>();
        m = board.Length;
        n = board[0].Length;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (board[i][j] == word[0])
                    start.Add((i, j));
            }
        }

        // Check every start
        foreach (var s in start)
        {
            int row = s.Item1;
            int col = s.Item2;
            // Console.WriteLine($"this start, row={row}, col={col}");
            visited = new bool[m, n];
            if (Backtrack(row, col, 1))
                return true;
        }
        return false;
    }

    bool[,] visited;
    bool Backtrack(int row, int col, int cnt)
    {
        if (cnt == word.Length)
            return true;
        else if (cnt > word.Length)
            return false;

        visited[row, col] = true;

        bool up = false, left = false, down = false, right = false;
        if (row > 0 && !visited[row - 1, col] && board[row - 1][col] == word[cnt])
            up = Backtrack(row - 1, col, cnt + 1);
        if (col > 0 && !visited[row, col - 1] && board[row][col - 1] == word[cnt])
            left = Backtrack(row, col - 1, cnt + 1);
        if (row < m - 1 && !visited[row + 1, col] && board[row + 1][col] == word[cnt])
            down = Backtrack(row + 1, col, cnt + 1);
        if (col < n - 1 && !visited[row, col + 1] && board[row][col + 1] == word[cnt])
            right = Backtrack(row, col + 1, cnt + 1);

        visited[row, col] = false;

        return up || left || down || right;
    }
}
// @lc code=end

