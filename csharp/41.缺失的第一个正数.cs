/*
 * @lc app=leetcode.cn id=41 lang=csharp
 *
 * [41] 缺失的第一个正数
 */

// @lc code=start
public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        // solution 1 : set
        // var set = new HashSet<int>();
        // int max = 0;
        // for (int i = 0; i < nums.Length; i++)
        // {
        //     if (nums[i] > 0)
        //         set.Add(nums[i]);
        //     max = Math.Max(max, nums[i]);
        // }
        // for (int i = 1; i <= max - 1; i++)
        // {
        //     if (!set.Contains(i))
        //         return i;
        // }
        // return max + 1;

        // solution 2: in place hash
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] <= 0)
                nums[i] = n + 1;
        }
        for (int i = 0; i < n; i++)
        {
            int num = Math.Abs(nums[i]);
            if (num <= n)
            {
                int tag = nums[num - 1];
                nums[num - 1] = -Math.Abs(tag);
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (nums[i] > 0)
                return i + 1;
        }
        return n + 1;
    }
}
// @lc code=end

