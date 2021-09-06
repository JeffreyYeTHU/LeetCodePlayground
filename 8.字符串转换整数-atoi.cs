using System;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
/*
 * @lc app=leetcode.cn id=8 lang=csharp
 *
 * [8] 字符串转换整数 (atoi)
 */

// @lc code=start
public class Solution
{
    public int MyAtoi (string s)
    {
        int i = 0;
        while (i < s.Length && s[i] == ' ')
            i++;
        long res = 0;
        bool neg = false;
        if (i < s.Length - 1 && (s[i] == '-' || s[i] == '+') && !Char.IsDigit (s[i + 1]))
            return 0;
        if (i < s.Length && s[i] == '-')
        {
            neg = true;
            i++;
        }
        if (i < s.Length && s[i] == '+')
        {
            i++;
        }
        if (i >= s.Length || !Char.IsDigit (s[i]))
            return 0;
        while (i < s.Length && Char.IsDigit (s[i]))
        {
            res = res * 10 + (s[i] - '0');
            if (!neg && res > int.MaxValue)
            {
                res = int.MaxValue;
                break;
            }
            if (neg && res > 1l + int.MaxValue)
            {
                res = 1l + int.MaxValue;
                break;
            }
            i++;
        }
        return neg ? (int) - res : (int) res;
    }
}
// @lc code=end