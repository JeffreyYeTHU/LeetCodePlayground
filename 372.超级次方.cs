/*
 * @lc app=leetcode.cn id=372 lang=csharp
 *
 * [372] 超级次方
 */

// @lc code=start
public class Solution
{
    readonly int d = 1337;
    public int SuperPow(int a, int[] b)
    {
        return PowHelper(a, b, b.Length - 1) % d;
    }

    // PowHelper(b, idx) = a^b[0..i]
    int PowHelper(int a, int[] b, int idx)
    {
        if (idx < 0)
            return 1;
        int part1 = CustomPow(a, b[idx]);
        int part2 = CustomPow(PowHelper(a, b, idx - 1), 10);
        return part1 * part2;
    }

    int CustomPow(int a, int b)
    {
        if (b == 0) return 1;
        a %= d;
        int res = 1;
        for (int i = 0; i < b; i++)
        {
            res *= a;
            res %= d;
        }
        return res;
    }
}
// @lc code=end

