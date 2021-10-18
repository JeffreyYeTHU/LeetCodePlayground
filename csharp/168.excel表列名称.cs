/*
 * @lc app=leetcode.cn id=168 lang=csharp
 *
 * [168] Excel表列名称
 */

// @lc code=start
public class Solution
{
    public string ConvertToTitle(int columnNumber)
    {
        // under the hood, it's about digit system conversion
        if (columnNumber == 1)
            return "A";
        var digits = new List<int>();
        while (columnNumber > 0)
        {
            columnNumber--;
            digits.Add(columnNumber % 26);
            columnNumber /= 26;
        }
        var sb = new StringBuilder();
        for (int i = digits.Count - 1; i >= 0; i--)
        {
            sb.Append((char)(digits[i] + 'A'));
        }
        return sb.ToString();
    }
}
// @lc code=end

