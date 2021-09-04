/*
 * @lc app=leetcode.cn id=20 lang=csharp
 *
 * [20] 有效的括号
 */

// @lc code=start
public class Solution
{
    public bool IsValid(string s)
    {
        var stk = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c == '(' || c == '[' || c == '{')
                stk.Push(c);
            else
            {
                if (stk.Count == 0)
                    return false;
                char top = stk.Pop();
                if (c == ')' && top != '(')
                    return false;
                if (c == ']' && top != '[')
                    return false;
                if (c == '}' && top != '{')
                    return false;
            }
        }
        return stk.Count == 0;
    }
}
// @lc code=end

