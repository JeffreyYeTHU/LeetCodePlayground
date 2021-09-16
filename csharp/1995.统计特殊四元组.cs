/*
 * @lc app=leetcode.cn id=1995 lang=csharp
 *
 * [1995] 统计特殊四元组
 */

// @lc code=start
public class Solution
{
    Dictionary<int, List<int>> valToIdx;
    int[] nums;
    public int CountQuadruplets(int[] nums)
    {
        // Setup
        this.nums = nums;
        valToIdx = new Dictionary<int, List<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!valToIdx.ContainsKey(nums[i]))
                valToIdx.Add(nums[i], new List<int>());
            valToIdx[nums[i]].Add(i);
        }

        // Compute
        int cnt = 0;
        for (int i = nums.Length - 1; i >= 3; i--)
        {
            for (int j = i - 1; j >= 2; j--)
            {
                int sum = nums[i] - nums[j];
                cnt += CountTwoSum(sum, 0, j - 1);
            }
        }
        return cnt;
    }

    // two sum to get sum within nums[left..right]
    public int CountTwoSum(int sum, int left, int right)
    {
        int cnt = 0;
        for (int i = left; i <= right; i++)
        {
            int target = sum - nums[i];
            if (valToIdx.ContainsKey(target))
            {
                foreach (var t in valToIdx[target])
                {
                    if (t > i && t <= right)
                        cnt++;
                }
            }
        }
        return cnt;
    }
}
// @lc code=end

