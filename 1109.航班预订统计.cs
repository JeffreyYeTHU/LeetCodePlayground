/*
 * @lc app=leetcode.cn id=1109 lang=csharp
 *
 * [1109] 航班预订统计
 */

// @lc code=start
public class Solution
{
    public int[] CorpFlightBookings(int[][] bookings, int n)
    {
        int[] diff = new int[n];
        for (int i = 0; i < bookings.Length; i++)
        {
            var book = bookings[i];
            diff[book[0] - 1] += book[2];
            if (book[1] < n)
                diff[book[1]] -= book[2];
        }
        int[] res = new int[n];
        res[0] = diff[0];
        for (int i = 1; i < n; i++)
            res[i] = res[i - 1] + diff[i];

        return res;
    }
}
// @lc code=end

