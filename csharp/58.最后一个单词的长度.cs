/*
 * @lc app=leetcode.cn id=58 lang=csharp
 *
 * [58] 最后一个单词的长度
 */

// @lc code=start
public class Solution
{
    public int LengthOfLastWord(string s)
    {
        int j = s.Length - 1;
        while (j >= 0 && s[j] == ' ')
            j--;
        int res = 0;
        while (j >= 0 && s[j] != ' ')
        {
            res++;
            j--;
        }
        return res;
    }
}
// @lc code=end

