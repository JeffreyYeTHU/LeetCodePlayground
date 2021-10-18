/*
 * @lc app=leetcode.cn id=171 lang=csharp
 *
 * [171] Excel 表列序号
 */

// @lc code=start
public class Solution
{
    public int TitleToNumber(string columnTitle)
    {
        int n = columnTitle.Length;
        int res = 0;
        for (int i = 0; i < n; i++)
            res += (columnTitle[i] - 'A' + 1) * (int)Math.Pow(26, n - 1 - i);
        return res;
    }
}
// @lc code=end

