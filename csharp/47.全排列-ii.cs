/*
 * @lc app=leetcode.cn id=47 lang=csharp
 *
 * [47] 全排列 II
 */

// @lc code=start
public class Solution
{
    int cnt;
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        this.cnt = nums.Length;
        Backtrack(nums.ToList(), new List<int>());
        return res;
    }

    List<IList<int>> res = new List<IList<int>>();
    HashSet<string> resset = new HashSet<string>();
    void Backtrack(List<int> options, List<int> path)
    {
        if (path.Count == cnt)
        {
            string key = ListToStr(path);
            if (!resset.Contains(key))
            {
                res.Add(new List<int>(path));
                resset.Add(key);
            }
            return;
        }

        for (int i = 0; i < options.Count; i++)
        {
            // make choice
            var d = options[i];
            path.Add(d);
            options.RemoveAt(i);
            Backtrack(options, path);

            // undo choice
            path.RemoveAt(path.Count - 1);
            options.Insert(i, d);
        }
    }

    string ListToStr(List<int> data)
    {
        var str = "";
        foreach (var d in data)
        {
            str += d + ",";
        }
        return str;
    }
}
// @lc code=end

