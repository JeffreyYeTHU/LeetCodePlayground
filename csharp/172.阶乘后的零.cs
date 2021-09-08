/*
 * @lc app=leetcode.cn id=172 lang=csharp
 *
 * [172] 阶乘后的零
 */

// @lc code=start
public class Solution
{
    public int TrailingZeroes(int n)
    {
        int cnt = 0;
        long d = 5;
        while (d <= n)
        {
            cnt += n / (int)d;
            d *= 5;
        }
        return cnt;
    }
}
// @lc code=end

