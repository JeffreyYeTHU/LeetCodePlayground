/*
 * @lc app=leetcode.cn id=820 lang=csharp
 *
 * [820] 单词的压缩编码
 */

// @lc code=start
public class Solution
{
    public int MinimumLengthEncoding(string[] words)
    {
        var remain = words.ToHashSet();
        foreach (var word in words)
        {
            for (int i = 1; i < word.Length; i++)
            {
                remain.Remove(word.Substring(i));
            }
        }
        int ans = 0;
        foreach (var r in remain)
        {
            ans += r.Length + 1;
        }
        return ans;
    }
}
// @lc code=end

