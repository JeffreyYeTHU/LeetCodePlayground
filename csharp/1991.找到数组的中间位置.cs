/*
 * @lc app=leetcode.cn id=1991 lang=csharp
 *
 * [1991] 找到数组的中间位置
 */

// @lc code=start
public class Solution
{
    public int FindMiddleIndex(int[] nums)
    {
        int n = nums.Length;
        int[] leftSum = new int[n];
        for (int i = 0; i < n; i++)
        {
            int pre = (i == 0) ? 0 : leftSum[i - 1];
            leftSum[i] = pre + nums[i];
        }
        for (int i = 0; i < n; i++)
        {
            int left = leftSum[i] - nums[i];
            int right = leftSum[n - 1] - leftSum[i];
            if (left == right)
                return i;
        }
        return -1;
    }
}
// @lc code=end

