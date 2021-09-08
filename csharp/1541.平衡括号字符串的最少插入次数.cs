/*
 * @lc app=leetcode.cn id=1541 lang=csharp
 *
 * [1541] 平衡括号字符串的最少插入次数
 */

// @lc code=start
public class Solution
{
    public int MinInsertions(string s)
    {
        int res = 0;
        int need = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                need += 2;
                if (need % 2 == 1)
                {
                    res++;
                    need--;
                }
            }
            else
            {
                need--;
                if (need == -1)
                {
                    res++;
                    need = 1;
                }
            }
        }
        return res + need;
    }
}
// @lc code=end

