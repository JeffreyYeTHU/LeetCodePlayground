/*
 * @lc app=leetcode.cn id=887 lang=csharp
 *
 * [887] 鸡蛋掉落
 */

// @lc code=start
public class Solution
{
    public int SuperEggDrop(int k, int n)
    {
        return Dp(k, n);
    }

    // for k eggs and n floors(can start at any floor, as long as the count is n)
    Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
    int Dp(int k, int n)
    {
        if (k == 1) return n;
        if (n == 0) return 0;
        if (memo.ContainsKey((k, n)))
            return memo[(k, n)];
        int res = int.MaxValue;
        // for (int i = 1; i <= n; i++)
        // {
        //     res = Math.Min(res, Math.Max(Dp(k - 1, i - 1), Dp(k, n - i)) + 1);
        // }
        int lo = 1;
        int hi = n;
        while (lo <= hi)
        {
            int mid = lo + (hi - lo) / 2;
            int broken = Dp(k - 1, mid - 1);
            int notBroken = Dp(k, n - mid);
            if (broken > notBroken)
            {
                res = Math.Min(res, broken + 1);
                hi = mid - 1;
            }
            else
            {
                res = Math.Min(res, notBroken + 1);
                lo = mid + 1;
            }
        }

        memo.Add((k, n), res);
        return memo[(k, n)];
    }
}
// @lc code=end

