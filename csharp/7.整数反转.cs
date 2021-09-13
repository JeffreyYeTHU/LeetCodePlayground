/*
 * @lc app=leetcode.cn id=7 lang=csharp
 *
 * [7] 整数反转
 */

// @lc code=start
public class Solution
{
    public int Reverse(int x)
    {
        int res = 0;
        int posThresh = int.MaxValue / 10;
        int negThresh = int.MinValue / 10;
        while (x != 0)
        {
            int digit = x % 10;
            if (res > posThresh || (res == posThresh && digit > 7))
                return 0;
            if (res < negThresh || (res == posThresh && digit < -8))
                return 0;
            res = res * 10 + digit;
            x /= 10;
        }
        return res;
    }
}
// @lc code=end

