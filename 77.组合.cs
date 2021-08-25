/*
 * @lc app=leetcode.cn id=77 lang=csharp
 *
 * [77] 组合
 */

// @lc code=start
public class Solution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        if (k <= 0 || n <= 0) return res;
        Backtrack(n, k, 1, new List<int>());
        return res;
    }

    List<IList<int>> res = new List<IList<int>>();
    void Backtrack(int n, int k, int start, List<int> path)
    {
        if (path.Count == k)
        {
            res.Add(new List<int>(path));
            return;
        }

        for (int i = start; i <= n; i++)
        {
            path.Add(i);
            Backtrack(n, k, i + 1, path);
            path.RemoveAt(path.Count - 1);
        }
    }
}
// @lc code=end

