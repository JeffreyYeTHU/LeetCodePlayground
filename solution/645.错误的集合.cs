/*
 * @lc app=leetcode.cn id=645 lang=csharp
 *
 * [645] 错误的集合
 */

// @lc code=start
public class Solution
{
    public int[] FindErrorNums(int[] nums)
    {
        int n = nums.Length;
        var res = new int[2];
        bool[] exist = new bool[n + 1];  // not use exist[0]
        for (int i = 0; i < n; i++)
        {
            if (exist[nums[i]])
                res[0] = nums[i];
            else
                exist[nums[i]] = true;
        }
        for (int i = 1; i <= n; i++)
        {
            if (!exist[i])
                res[1] = i;
        }
        return res;
    }
}
// @lc code=end

