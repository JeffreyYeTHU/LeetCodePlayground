/*
 * @lc app=leetcode.cn id=69 lang=csharp
 *
 * [69] x 的平方根
 */

// @lc code=start
public class Solution
{
    public int MySqrt(int x)
    {
        // solution 1: binary search, find right bound
        if (x <= 1) return x;
        long low = 1;
        long high = x;
        while (low <= high)
        {
            long mid = low + (high - low) / 2;
            long square = mid * mid;
            if (square == x)
            {
                return (int)mid;
            }
            else if (square < x)
            {
                low = mid + 1;
            }
            else if (square > x)
            {
                high = mid - 1;
            }
        }
        return (int)high;
    }
}
// @lc code=end

