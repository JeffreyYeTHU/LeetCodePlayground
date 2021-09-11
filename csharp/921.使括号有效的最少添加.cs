/*
 * @lc app=leetcode.cn id=921 lang=csharp
 *
 * [921] 使括号有效的最少添加
 */

// @lc code=start
public class Solution
{
    public int MinAddToMakeValid(string s)
    {
        var stk = new Stack<char>();
        int minCnt = 0;
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c == '(')
                stk.Push(c);
            else
            {
                if (stk.Count == 0)
                    minCnt++;
                else
                    stk.Pop();
            }
        }
        return minCnt + stk.Count;
    }
}
// @lc code=end

