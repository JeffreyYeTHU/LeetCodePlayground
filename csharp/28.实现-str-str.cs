/*
 * @lc app=leetcode.cn id=28 lang=csharp
 *
 * [28] 实现 strStr()
 */

// @lc code=start
public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        if (needle.Length > haystack.Length)
            return -1;
        else if (needle == "" && haystack == "")
            return 0;
        for (int i = 0; i < haystack.Length; i++)
        {
            if (IsSubFrom(haystack, i, needle))
                return i;
        }
        return -1;
    }

    bool IsSubFrom(string haystack, int start, string needle)
    {
        int m = haystack.Length;
        int n = needle.Length;
        if (start < 0 || start + n > m)
            return false;
        for (int i = 0; i < n; i++)
        {
            if (haystack[start + i] != needle[i])
                return false;
        }
        return true;
    }
}
// @lc code=end

