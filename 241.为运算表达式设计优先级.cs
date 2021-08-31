/*
 * @lc app=leetcode.cn id=241 lang=csharp
 *
 * [241] 为运算表达式设计优先级
 */

// @lc code=start
public class Solution
{
    public IList<int> DiffWaysToCompute(string expression)
    {
        var res = new List<int>();
        for (int i = 0; i < expression.Length; i++)
        {
            char op = expression[i];
            if (op == '+' || op == '-' || op == '*')
            {
                var left = DiffWaysToCompute(expression.Substring(0, i));
                var right = DiffWaysToCompute(expression.Substring(i + 1));
                foreach (var le in left)
                {
                    foreach (var ri in right)
                    {
                        if (op == '+')
                            res.Add(le + ri);
                        else if (op == '-')
                            res.Add(le - ri);
                        else if (op == '*')
                            res.Add(le * ri);
                    }
                }
            }
        }

        if (res.Count == 0)
            res.Add(int.Parse(expression));

        return res;
    }
}
// @lc code=end

