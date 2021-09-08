/*
 * @lc app=leetcode.cn id=1 lang=csharp
 *
 * [1] 两数之和
 */

// @lc code=start
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var valToIdx = new Dictionary<int, List<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!valToIdx.ContainsKey(nums[i]))
                valToIdx.Add(nums[i], new List<int>() { i });
            else
                valToIdx[nums[i]].Add(i);
        }
        for (int i = 0; i < nums.Length; i++)
        {
            int match = target - nums[i];
            if (match == nums[i] && valToIdx[match].Count > 1)
            {
                var idx = valToIdx[match];
                return new int[] { idx[0], idx[1] };
            }
            else if (match != nums[i] && valToIdx.ContainsKey(match))
                return new int[] { i, valToIdx[match][0] };
        }
        return new int[] { -1, -1 };
    }
}
// @lc code=end

