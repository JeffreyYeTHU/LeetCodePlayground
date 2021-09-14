/*
 * @lc app=leetcode.cn id=70 lang=csharp
 *
 * [70] 爬楼梯
 */

// @lc code=start
public class Solution
{
    Dictionary<int, int> memo = new Dictionary<int, int>();
    public int ClimbStairs(int n)
    {
        // // solution 1: recursive
        // if (n == 1)
        //     return 1;
        // else if (n == 2)
        //     return 2;

        // if (memo.ContainsKey(n))
        //     return memo[n];
        // int res = ClimbStairs(n - 1) + ClimbStairs(n - 2);
        // memo.Add(n, res);
        // return res;

        // solution 2: dp
        if (n == 1)
            return 1;
        else if (n == 2)
            return 2;
        int prepre = 1, pre = 2;
        for (int i = 3; i <= n; i++)
        {
            int curr = prepre + pre;
            prepre = pre;
            pre = curr;
        }
        return pre;
    }
}
// @lc code=end

