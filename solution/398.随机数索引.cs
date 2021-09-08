/*
 * @lc app=leetcode.cn id=398 lang=csharp
 *
 * [398] 随机数索引
 */

// @lc code=start
public class Solution
{

    public Solution(int[] nums)
    {
        vals = nums;
        rnd = new Random();
    }

    int[] vals;
    Random rnd;
    public int Pick(int target)
    {
        int res = -1;
        var choice = new List<int>();
        for (int i = 0; i < vals.Length; i++)
        {
            if (vals[i] == target)
            {
                choice.Add(i);
                if (rnd.Next(choice.Count) == 0)
                    res = i;
            }
        }
        return res;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int param_1 = obj.Pick(target);
 */
// @lc code=end

