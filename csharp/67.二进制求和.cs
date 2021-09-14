/*
 * @lc app=leetcode.cn id=67 lang=csharp
 *
 * [67] 二进制求和
 */

// @lc code=start
public class Solution
{
    public string AddBinary(string a, string b)
    {
        var stk = new Stack<char>();
        int i = a.Length - 1;
        int j = b.Length - 1;
        int carry = 0;
        while (i >= 0 || j >= 0)
        {
            int first = (i < 0) ? 0 : a[i] - '0';
            int second = (j < 0) ? 0 : b[j] - '0';
            int sum = carry + first + second;
            if (sum >= 2)
            {
                carry = 1;
                int digit = sum % 2 + '0';
                stk.Push((char)digit);
            }
            else
            {
                carry = 0;
                stk.Push((char)(sum + '0'));
            }
            i--;
            j--;
        }
        if (carry == 1)
            stk.Push('1');
        var sb = new StringBuilder();
        while (stk.Count != 0)
        {
            sb.Append(stk.Pop());
        }
        return sb.ToString();
    }
}
// @lc code=end

