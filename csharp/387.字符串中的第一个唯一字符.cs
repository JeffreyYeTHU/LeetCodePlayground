/*
 * @lc app=leetcode.cn id=387 lang=csharp
 *
 * [387] 字符串中的第一个唯一字符
 */

// @lc code=start
public class Solution
{
    public int FirstUniqChar(string s)
    {
        int[] cnt = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            cnt[s[i] - 'a']++;
        }
        for (int i = 0; i < s.Length; i++)
        {
            if (cnt[s[i] - 'a'] == 1)
                return i;
        }
        return -1;
    }
}
// @lc code=end

