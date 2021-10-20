/*
 * @lc app=leetcode.cn id=238 lang=csharp
 *
 * [238] 除自身以外数组的乘积
 */

// @lc code=start
public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        int mul = 1;
        foreach (var num in nums)
            mul *= num;
        int[] res = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
                res[i] = mul / nums[i];
            else
                res[i] = MulExcept(nums, i);
        }
        return res;
    }

    int MulExcept(int[] nums, int idx)
    {
        int mul = 1;
        for (int i = 0; i < nums.Length; i++)
            if (i != idx)
                mul *= nums[i];
        return mul;
    }
}
// @lc code=end

