/*
 * @lc app=leetcode.cn id=964 lang=csharp
 *
 * [964] 表示数字的最少运算符
 */

// @lc code=start
public class Solution
{

    Dictionary<string, int> memo = new Dictionary<string, int>();
    int x;
    public int LeastOpsExpressTarget(int x, int target)
    {
        this.x = x;
        return Dp(0, target) - 1;
    }

    public int Dp(int i, int target)
    {
        String code = "" + i + "#" + target;
        if (memo.ContainsKey(code))
            return memo[code];

        int ans;
        if (target == 0)
        {
            ans = 0;
        }
        else if (target == 1)
        {
            ans = Cost(i);
        }
        else if (i >= 39)
        {
            ans = target + 1;
        }
        else
        {
            int t = target / x;
            int r = target % x;
            ans = Math.Min(r * Cost(i) + Dp(i + 1, t),
                           (x - r) * Cost(i) + Dp(i + 1, t + 1));
        }

        memo.Add(code, ans);
        return ans;
    }

    public int Cost(int x)
    {
        return x > 0 ? x : 2;
    }
}
// @lc code=end

