/*
 * @lc app=leetcode.cn id=78 lang=csharp
 *
 * [78] 子集
 */

// @lc code=start
public class Solution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        Backtrack(nums, 0, new List<int>());
        return res;
    }

    List<IList<int>> res = new List<IList<int>>();
    void Backtrack(int[] nums, int start, List<int> path)
    {
        res.Add(new List<int>(path));
        for (int i = start; i < nums.Length; i++)
        {
            path.Add(nums[i]);
            Backtrack(nums, i + 1, path);
            path.RemoveAt(path.Count - 1);
        }
    }
}
// @lc code=end

