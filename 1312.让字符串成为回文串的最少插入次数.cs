/*
 * @lc app=leetcode.cn id=1312 lang=csharp
 *
 * [1312] 让字符串成为回文串的最少插入次数
 */

// @lc code=start
public class Solution
{
    public int MinInsertions(string s)
    {
        return Dp(s, 0, s.Length - 1);
    }

    // The min steps of s[i..j]
    Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
    int Dp(string s, int i, int j)
    {
        if (i >= j)
            return 0;

        if (memo.ContainsKey((i, j)))
            return memo[(i, j)];
        int res;
        if (s[i] == s[j])
        {
            res = Dp(s, i + 1, j - 1);
        }
        else
        {
            res = Math.Min(
                Dp(s, i + 1, j) + 1,
                Dp(s, i, j - 1) + 1
            );
        }
        memo.Add((i, j), res);
        return res;
    }
}
// @lc code=end

