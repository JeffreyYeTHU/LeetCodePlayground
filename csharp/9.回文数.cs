using System;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
/*
 * @lc app=leetcode.cn id=9 lang=csharp
 *
 * [9] 回文数
 */

// @lc code=start
public class Solution
{
    public bool IsPalindrome (int x)
    {
        // // solution 1: convert to string
        // var s = x.ToString ();
        // return IsPalindrome (s);

        // solution 2: get digits
        if (x < 0) return false;
        var digits = new List<int> ();
        while (x != 0)
        {
            digits.Add (x % 10);
            x /= 10;
        }
        int i = 0, j = digits.Count - 1;
        while (i < digits.Count && j >= 0 && i <= j)
        {
            if (digits[i] != digits[j])
                return false;
            i++;
            j--;
        }
        return true;
    }

    bool IsPalindrome (string s)
    {
        int i = 0, j = s.Length - 1;
        while (i < s.Length && j >= 0 && i <= j)
        {
            if (s[i] != s[j])
                return false;
            i++;
            j--;
        }
        return true;
    }
}
// @lc code=end