/*
 * @lc app=leetcode.cn id=300 lang=csharp
 *
 * [300] 最长递增子序列
 */

// @lc code=start
public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        // // solution 1: backtracking
        // var path = new List<int>();
        // return BackTrack(nums, 0, path);

        // // solution 2: dp
        // // the c# really missing some important basic function
        // // like priority queue and actual sorted list(it is dic in the current implementation) 
        // int[] dp = new int[nums.Length];
        // Array.Fill(dp, 1);  // init value
        // for (int i = 1; i < nums.Length; i++)
        // {
        //     for (int j = 0; j < i; j++)
        //     {
        //         if (nums[j] < nums[i])
        //             dp[i] = Math.Max(dp[i], dp[j] + 1);
        //     }
        // }
        // return dp.Max();

        // solution 3: patience sort
        List<List<int>> pile = new List<List<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            int target = nums[i];
            int idx = FindIdx(pile, target);
            if (idx == pile.Count)
            {
                pile.Add(new List<int>());
                pile[idx].Add(target);
            }
            else
            {
                if (pile[idx].Last() != target)
                    pile[idx].Add(target);
            }
        }
        return pile.Count;
    }

    private int FindIdx(List<List<int>> pile, int target)
    {
        // use binary search to find left lower bound
        // range [lo, hi]
        int lo = 0;
        int hi = pile.Count - 1;
        while (lo <= hi)
        {
            int mid = lo + (hi - lo) / 2;
            int midTop = pile[mid].Last();
            if (midTop == target)
            {
                lo = mid;
                break;
            }
            else if (midTop > target)
            {
                hi = mid - 1;
            }
            else if (midTop < target)
            {
                lo = mid + 1;
            }
        }
        return lo;
    }

    private int BackTrack(int[] nums, int i, List<int> path)
    {
        if (i >= nums.Length)
            return path.Count;

        if (path.Count == 0 || nums[i] > path[path.Count - 1])
        {
            // not include current
            int notInclude = BackTrack(nums, i + 1, path);

            // include current
            path.Add(nums[i]);
            int include = BackTrack(nums, i + 1, path);
            path.RemoveAt(path.Count - 1);

            return Math.Max(notInclude, include);
        }
        else
        {
            return BackTrack(nums, i + 1, path);
        }
    }
}
// @lc code=end

