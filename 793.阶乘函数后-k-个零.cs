/*
 * @lc app=leetcode.cn id=793 lang=csharp
 *
 * [793] 阶乘函数后 K 个零
 */

// @lc code=start
public class Solution
{
    public int PreimageSizeFZF(int k)
    {
        if (k < 0) return 0;

        // left bound
        long lo = 0;
        long hi = long.MaxValue;
        while (lo <= hi)
        {
            long mid = lo + (hi - lo) / 2;
            long zeroCnt = TrailingZeroes(mid);
            if (zeroCnt == k)
                hi = mid - 1;
            else if (zeroCnt > k)
                hi = mid - 1;
            else if (zeroCnt < k)
                lo = mid + 1;
        }
        long leftBound = lo;

        // right bound
        lo = 0;
        hi = long.MaxValue;
        while (lo <= hi)
        {
            long mid = lo + (hi - lo) / 2;
            long zeroCnt = TrailingZeroes(mid);
            if (zeroCnt == k)
                lo = mid + 1;
            else if (zeroCnt < k)
                lo = mid + 1;
            else if (zeroCnt > k)
                hi = mid - 1;
        }
        long rightBound = hi;
        return (int)(rightBound - leftBound + 1);
    }

    long TrailingZeroes(long n)
    {
        long res = 0;
        long d = 5;
        while (d <= n)
        {
            res += n / d;
            d *= 5;
        }
        return res;
    }
}
// @lc code=end

