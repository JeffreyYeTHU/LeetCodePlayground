/*
 * @lc app=leetcode.cn id=448 lang=csharp
 *
 * [448] 找到所有数组中消失的数字
 */

// @lc code=start
public class Solution
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        int n = nums.Length;
        bool[] exist = new bool[n + 1];
        for (int i = 0; i < n; i++)
            exist[nums[i]] = true;
        var res = new List<int>();
        for (int i = 1; i <= n; i++)
            if (!exist[i])
                res.Add(i);
        return res;
    }
}
// @lc code=end

