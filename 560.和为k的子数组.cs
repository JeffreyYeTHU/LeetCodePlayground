/*
 * @lc app=leetcode.cn id=560 lang=csharp
 *
 * [560] 和为K的子数组
 */

// @lc code=start
public class Solution
{
    public int SubarraySum(int[] nums, int k)
    {
        var presumToCnt = new Dictionary<int, int>();
        presumToCnt.Add(0, 1);
        int cnt = 0;
        int presum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            presum += nums[i];
            int target = presum - k;
            if (presumToCnt.ContainsKey(target))
                cnt += presumToCnt[target];
            if (presumToCnt.ContainsKey(presum))
                presumToCnt[presum] += 1;
            else
                presumToCnt.Add(presum, 1);
        }
        return cnt;
    }
}
// @lc code=end

