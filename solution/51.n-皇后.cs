/*
 * @lc app=leetcode.cn id=51 lang=csharp
 *
 * [51] N 皇后
 */

// @lc code=start
public class Solution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        Backtrack(new List<int>(), 0, n);
        return result;
    }

    List<IList<string>> result = new List<IList<string>>();
    void Backtrack(List<int> queenPos, int row, int n)
    {
        if (queenPos.Count == n)
            result.Add(GetResStr(queenPos, n));

        for (int j = 0; j < n; j++)
        {
            if (IsValidPos(queenPos, row, j, n))
            {
                queenPos.Add(j);
                Backtrack(queenPos, row + 1, n);
                queenPos.RemoveAt(queenPos.Count - 1);
            }
        }
    }

    // queenPos is formated as row by row, so only record the col idx
    List<string> GetResStr(List<int> queenPos, int n)
    {
        var res = new List<string>();
        foreach (var pos in queenPos)
        {
            var s = new string('.', n);
            var sq = s.Remove(pos, 1).Insert(pos, "Q");
            res.Add(sq);
        }
        return res;
    }

    bool IsValidPos(List<int> queenPos, int row, int col, int n)
    {
        for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
        {
            if (queenPos[i] == j)
                return false;
        }

        for (int i = row - 1; i >= 0; i--)
        {
            if (queenPos[i] == col)
                return false;
        }

        for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++)
        {
            if (queenPos[i] == j)
                return false;
        }

        return true;
    }
}
// @lc code=end

