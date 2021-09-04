/*
 * @lc app=leetcode.cn id=224 lang=csharp
 *
 * [224] 基本计算器
 */

// @lc code=start
public class Solution
{
    public int Calculate(string s)
    {
        return Compute(new LinkedList<char>(s.ToCharArray()));
    }

    int Compute(LinkedList<char> strChars)
    {
        var stk = new Stack<int>();
        char op = '+';
        int num = 0;
        while (strChars.Count != 0)
        {
            char c = strChars.First();
            strChars.RemoveFirst();

            if (c == '(')
                num = Compute(strChars);

            if (char.IsDigit(c))
                num = num * 10 + (c - '0');

            if ((!char.IsDigit(c) && c != ' ') || strChars.Count == 0)
            {
                switch (op)
                {
                    case '+':
                        stk.Push(num);
                        break;

                    case '-':
                        stk.Push(-num);
                        break;
                }

                // update sign and num
                num = 0;
                op = c;
            }

            if (c == ')')
                break;
        }

        return stk.Sum();
    }
}
// @lc code=end

