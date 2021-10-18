/*
 * @lc app=leetcode.cn id=151 lang=csharp
 *
 * [151] 翻转字符串里的单词
 */

// @lc code=start
public class Solution
{
    public string ReverseWords(string s)
    {
        string[] words = s.Split(' ');
        StringBuilder sb = new();
        for (int i = words.Length - 1; i >= 0; i--)
        {
            string word = words[i];
            if (word != "")
            {
                sb.Append(word);
                sb.Append(" ");
            }
        }
        sb.Remove(sb.Length - 1, 1);
        return sb.ToString();
    }
}
// @lc code=end

