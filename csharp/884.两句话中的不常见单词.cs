/*
 * @lc app=leetcode.cn id=884 lang=csharp
 *
 * [884] 两句话中的不常见单词
 */

// @lc code=start
public class Solution
{
    public string[] UncommonFromSentences(string s1, string s2)
    {
        var dic1 = new Dictionary<string, int>();
        var dic2 = new Dictionary<string, int>();
        foreach (var word in s1.Split(' '))
        {
            if (!dic1.ContainsKey(word))
                dic1.Add(word, 0);
            dic1[word]++;
        }
        foreach (var word in s2.Split(' '))
        {
            if (!dic2.ContainsKey(word))
                dic2.Add(word, 0);
            dic2[word]++;
        }
        var res = new List<string>();
        foreach (var key in dic1.Keys)
        {
            if (dic1[key] == 1 && !dic2.ContainsKey(key))
                res.Add(key);
        }
        foreach (var key in dic2.Keys)
        {
            if (dic2[key] == 1 && !dic1.ContainsKey(key))
                res.Add(key);
        }
        return res.ToArray();
    }
}
// @lc code=end

