/*
 * @lc app=leetcode.cn id=22 lang=csharp
 *
 * [22] 括号生成
 */

// @lc code=start
public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        var sb = new StringBuilder();
        Backtrack(n, n, sb);
        return res;
    }

    List<string> res = new List<string>();
    void Backtrack(int leftParen, int rightParen, StringBuilder sb)
    {
        if (leftParen > rightParen) return;
        if (leftParen < 0 || rightParen < 0) return;
        if (leftParen == 0 && rightParen == 0)
        {
            res.Add(sb.ToString());
            return;
        }

        // left
        sb.Append("(");
        Backtrack(leftParen - 1, rightParen, sb);
        sb.Remove(sb.Length - 1, 1);

        // right
        sb.Append(")");
        Backtrack(leftParen, rightParen - 1, sb);
        sb.Remove(sb.Length - 1, 1);

    }
}
// @lc code=end

