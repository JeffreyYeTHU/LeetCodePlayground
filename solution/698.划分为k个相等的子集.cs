/*
 * @lc app=leetcode.cn id=698 lang=csharp
 *
 * [698] 划分为k个相等的子集
 */

// @lc code=start
public class Solution
{
    public bool CanPartitionKSubsets(int[] nums, int k)
    {
        int sum = nums.Sum();
        if (sum % k != 0) return false;
        int target = sum / k;
        Array.Sort(nums);
        var sortedNums = nums.OrderByDescending(n => n).ToArray();
        Backtrack(sortedNums, 0, new int[k], target);
        return canPartition;
    }

    // setSums is int[4], denote the current sum of these sets
    bool canPartition = false;
    void Backtrack(int[] nums, int idx, int[] setSums, int target)
    {
        if (idx == nums.Length)
        {
            if (AllEleIs(setSums, target))
                canPartition = true;
            return;
        }

        if (canPartition)
            return;

        for (int i = 0; i < setSums.Length; i++)
        {
            if (setSums[i] + nums[idx] <= target)
            {
                // make choice
                setSums[i] += nums[idx];
                Backtrack(nums, idx + 1, setSums, target);

                // undo choice
                setSums[i] -= nums[idx];
            }
        }
    }

    bool AllEleIs(int[] sums, int target)
    {
        bool allIsTarget = true;
        for (int i = 0; i < sums.Length; i++)
            allIsTarget = allIsTarget && sums[i] == target;
        return allIsTarget;
    }
}
// @lc code=end

