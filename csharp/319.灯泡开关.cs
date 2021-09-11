/*
 * @lc app=leetcode.cn id=319 lang=csharp
 *
 * [319] 灯泡开关
 */

// @lc code=start
public class Solution
{
    public int BulbSwitch(int n)
    {
        // solution 1:
        return (int)Math.Sqrt(n);

        // // solution 2:
        // if (n == 0) return 0;
        // bool[] isOn = new bool[n + 1];  // not use isOn[0]
        // for (int i = 1; i <= n; i++)
        // {
        //     for (int j = i; j <= n; j += i)
        //         isOn[j] = !isOn[j];
        // }
        // int cnt = 0;
        // for (int i = 1; i <= n; i++)
        // {
        //     if (isOn[i])
        //         cnt++;
        // }
        // return cnt;
    }
}
// @lc code=end

