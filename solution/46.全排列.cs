/*
 * @lc app=leetcode.cn id=46 lang=csharp
 *
 * [46] 全排列
 */

// @lc code=start
public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        Backtrack(nums.ToList(), new List<int>(), nums.Length);
        return res;
    }

    List<IList<int>> res = new List<IList<int>>();
    void Backtrack(List<int> options, List<int> path, int len)
    {
        // base case
        if (path.Count == len)
            res.Add(new List<int>(path));

        // backtrack
        for (int i = 0; i < options.Count; i++)
        {
            // choice
            int v = options[i];
            options.RemoveAt(i);
            path.Add(v);
            Backtrack(options, path, len);

            // undo choice
            path.RemoveAt(path.Count - 1);
            options.Insert(i, v);
        }
    }
}
// @lc code=end

