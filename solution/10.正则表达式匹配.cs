/*
 * @lc app=leetcode.cn id=10 lang=csharp
 *
 * [10] 正则表达式匹配
 */

// @lc code=start
public class Solution
{
    public bool IsMatch(string s, string p)
    {
        return Dp(s, 0, p, 0);
    }

    Dictionary<(int, int), bool> memo = new Dictionary<(int, int), bool>();
    bool Dp(string s, int i, string p, int j)
    {
        if (j >= p.Length)
            return i >= s.Length;
        else if (i >= s.Length)
        {
            // check if the remain p can match empty string
            if ((p.Length - j) % 2 != 0)
                return false;
            else
            {
                for (; j + 1 < p.Length; j += 2)
                {
                    if (p[j + 1] != '*')
                        return false;
                }
                return true;
            }
        }

        if (memo.ContainsKey((i, j)))
            return memo[(i, j)];

        bool res = false;
        if (s[i] == p[j] || p[j] == '.')
        {
            if (j < p.Length - 1 && p[j + 1] == '*')
            {
                // match o to cnt, do choice
                res = Dp(s, i, p, j + 2) || Dp(s, i + 1, p, j);
            }
            else
            {
                res = Dp(s, i + 1, p, j + 1);
            }
        }
        else
        {
            if (j < p.Length - 1 && p[j + 1] == '*')
                res = Dp(s, i, p, j + 2);
            else
                res = false;
        }
        memo.Add((i, j), res);
        return memo[(i, j)];
    }
}
// @lc code=end

