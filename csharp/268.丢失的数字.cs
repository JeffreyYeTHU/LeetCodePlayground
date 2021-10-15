/*
 * @lc app=leetcode.cn id=268 lang=csharp
 *
 * [268] 丢失的数字
 */

// @lc code=start
public class Solution
{
    public int MissingNumber(int[] nums)
    {
        // // Using math
        // int sum = nums.Sum();
        // int n = nums.Length;
        // return n * (n + 1) / 2 - sum;

        // using XOR
        int missing = nums.Length;
        for (int i = 0; i < nums.Length; i++)
            missing ^= i ^ nums[i];
        return missing;
    }
}
// @lc code=end

