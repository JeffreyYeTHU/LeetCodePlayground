/*
 * @lc app=leetcode.cn id=191 lang=csharp
 *
 * [191] 位1的个数
 */

// @lc code=start
public class Solution
{
    public int HammingWeight(uint n)
    {
        // // solution 1: check the last every time
        // int weight = 0;
        // while (n != 0)
        // {
        //     if ((n & 1) != 0)
        //         weight++;
        //     n = n >> 1;
        // }
        // return weight;

        // solution 2: check the last 1
        int w = 0;
        while (n != 0)
        {
            n &= n - 1;
            w++;
        }
        return w;
    }
}
// @lc code=end

