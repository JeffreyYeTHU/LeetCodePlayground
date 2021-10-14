/*
 * @lc app=leetcode.cn id=91 lang=csharp
 *
 * [91] 解码方法
 */

// @lc code=start
public class Solution
{
    public int NumDecodings(string s)
    {
        this.s = s;
        return Dp(0);
    }

    string s;
    Dictionary<int, int> memo = new Dictionary<int, int>();
    // Dp(i): num of decoding for s[idx...end]
    int Dp(int idx)
    {
        if (idx >= s.Length)
            return 1;
        else if (s[idx] == '0')
            return 0;

        if (memo.ContainsKey(idx))
            return memo[idx];

        int oneway = Dp(idx + 1);
        int anotherway = 0;
        if (idx + 1 < s.Length && (s[idx] == '1' || (s[idx] == '2' && s[idx + 1] < '7')))
            anotherway = Dp(idx + 2);
        int res = oneway + anotherway;
        memo.Add(idx, res);
        return res;
    }
}
// @lc code=end

