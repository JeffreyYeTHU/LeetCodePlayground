using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
/*
 * @lc app=leetcode.cn id=13 lang=csharp
 *
 * [13] 罗马数字转整数
 */

// @lc code=start
public class Solution
{
    public int RomanToInt (string s)
    {
        var dic = new Dictionary<char, int> ();
        dic.Add ('I', 1);
        dic.Add ('V', 5);
        dic.Add ('X', 10);
        dic.Add ('L', 50);
        dic.Add ('C', 100);
        dic.Add ('D', 500);
        dic.Add ('M', 1000);
        int res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int curr = dic[s[i]];
            if (i + 1 < s.Length && curr < dic[s[i + 1]])
                res -= curr;
            else
                res += curr;
        }
        return res;
    }
}
// @lc code=end