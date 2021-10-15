/*
 * @lc app=leetcode.cn id=258 lang=csharp
 *
 * [258] 各位相加
 */

// @lc code=start
public class Solution
{
    public int AddDigits(int num)
    {
        // Recursive
        // if (num < 10)
        //     return num;

        // int digitSum = 0;
        // while (num >= 1)
        // {
        //     digitSum += num % 10;
        //     num /= 10;
        // }
        // return AddDigits(digitSum);

        // Math
        return (num - 1) % 9 + 1;
    }
}
// @lc code=end

