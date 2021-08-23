/*
 * @lc app=leetcode.cn id=312 lang=csharp
 *
 * [312] 戳气球
 */

// @lc code=start
public class Solution
{
    public int MaxCoins(int[] nums)
    {
        int n = nums.Length;
        int[] arr = new int[n + 2];
        arr[0] = 1;
        arr[n + 1] = 1;
        for (int i = 1; i <= n; i++)
            arr[i] = nums[i - 1];
        return Dp(arr, 0, n + 1);
    }

    // Dp[i, j] = 戳破（i, j）之间的气球的最大得分
    Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
    int Dp(int[] nums, int i, int j)
    {
        if (j <= i + 1) return 0;

        if (memo.ContainsKey((i, j)))
            return memo[(i, j)];
        int res = int.MinValue;
        for (int k = i + 1; k < j; k++)
        {
            int curr = Dp(nums, i, k) + Dp(nums, k, j) + nums[i] * nums[k] * nums[j];
            res = Math.Max(res, curr);
        }
        memo.Add((i, j), res);
        return memo[(i, j)];
    }

    // int Backtrack(List<int> bubbles, int[] nums)
    // {
    //     if (bubbles.Count == 1)
    //         return nums[bubbles[0]];

    //     int maxCoin = 0;
    //     for (int i = 0; i < bubbles.Count; i++)
    //     {
    //         // compute current
    //         int left = i == 0 ? 1 : nums[bubbles[i - 1]];
    //         int right = i == bubbles.Count - 1 ? 1 : nums[bubbles[i + 1]];
    //         int coins = left * nums[bubbles[i]] * right;

    //         // make choice
    //         int idx = bubbles[i];
    //         bubbles.RemoveAt(i);
    //         maxCoin = Math.Max(maxCoin, Backtrack(bubbles, nums) + coins);

    //         // undo choice
    //         bubbles.Insert(i, idx);
    //     }
    //     return maxCoin;
    // }
}
// @lc code=end

