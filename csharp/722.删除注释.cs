/*
 * @lc app=leetcode.cn id=722 lang=csharp
 *
 * [722] 删除注释
 */

// @lc code=start
public class Solution
{
    public IList<string> RemoveComments(string[] source)
    {
        var res = new List<string>();
        bool inBlockComment = false;
        var sb = new StringBuilder();
        foreach (var line in source)
        {
            // Start of a line, if not in block comment, accumulate chars from start
            if (!inBlockComment)
                sb.Clear();

            // Process current line
            int i = 0;
            while (i < line.Length)
            {
                if (!inBlockComment && line[i] == '/' && i + 1 < line.Length && line[i + 1] == '*')
                {
                    inBlockComment = true;
                    i++;
                }
                else if (inBlockComment && line[i] == '*' && i + 1 < line.Length && line[i + 1] == '/')
                {
                    inBlockComment = false;
                    i++;
                }
                else if (!inBlockComment && line[i] == '/' && i + 1 < line.Length && line[i + 1] == '/')
                {
                    break;
                }
                else if (!inBlockComment)
                {
                    sb.Append(line[i]);
                }
                i++;
            }

            // At the end of line, add a new line if not in block comment
            if (!inBlockComment && sb.Length > 0)
                res.Add(sb.ToString());
        }
        return res;
    }
}
// @lc code=end

