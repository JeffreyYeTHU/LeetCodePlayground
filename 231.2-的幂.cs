/*
 * @lc app=leetcode.cn id=231 lang=csharp
 *
 * [231] 2 的幂
 */

// @lc code=start
public class Solution
{
    public bool IsPowerOfTwo(int n)
    {
        // only have 1 bit with 1
        if (n <= 0) return false;
        return (n & (n - 1)) == 0;
    }
}
// @lc code=end

