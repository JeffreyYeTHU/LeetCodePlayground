/*
 * @lc app=leetcode.cn id=801 lang=csharp
 *
 * [801] 使序列递增的最小交换次数
 */

// @lc code=start
public class Solution
{
    int[] nums1, nums2;
    public int MinSwap(int[] nums1, int[] nums2)
    {
        this.nums1 = nums1;
        this.nums2 = nums2;
        (int origin, int swap) = Dp(nums1.Length - 1);
        return Math.Min(origin, swap);
    }

    // Dp(i): To get ordered seq for nums[0...i], Origin denote not swap num[i], Swap denote swap num[i]
    (int Origin, int Swap) Dp(int i)
    {
        if (i == 0)
            return (0, 1);

        (int preOrigin, int preSwap) = Dp(i - 1);
        int origin = int.MaxValue;
        int swap = int.MaxValue;
        if (nums1[i - 1] < nums1[i] && nums2[i - 1] < nums2[i])
        {
            origin = Math.Min(origin, preOrigin);
            swap = Math.Min(swap, preSwap + 1);
        }
        if (nums1[i - 1] < nums2[i] && nums2[i - 1] < nums1[i])
        {
            origin = Math.Min(origin, preSwap);
            swap = Math.Min(swap, preOrigin + 1);
        }
        return (origin, swap);
    }
}
// @lc code=end

