/*
 * @lc app=leetcode.cn id=14 lang=csharp
 *
 * [14] 最长公共前缀
 */

// @lc code=start
public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        int n = strs.Length;
        if (n == 1) return strs[0];
        string res = "";
        for (int i = 0; i < strs[0].Length; i++)
        {
            char curr = strs[0][i];
            for (int j = 1; j < n; j++)
            {
                if (i >= strs[j].Length || strs[j][i] != curr)
                    return res;
            }
            res += curr;
        }
        return res;
    }
}
// @lc code=end

