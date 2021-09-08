/*
 * @lc app=leetcode.cn id=292 lang=csharp
 *
 * [292] Nim 游戏
 */

// @lc code=start
public class Solution
{
    public bool CanWinNim(int n)
    {
        // solution 1: recursive
        // if (n <= 3)
        //     return true;
        // else if (n == 4)
        //     return false;
        // else if (n == 5 || n == 6 || n == 7)
        //     return true;
        // bool takeOne = CanWinNim(n - 2) && CanWinNim(n - 3) && CanWinNim(n - 4);
        // bool takeTwo = CanWinNim(n - 3) && CanWinNim(n - 4) && CanWinNim(n - 5);
        // bool takeThree = CanWinNim(n - 4) && CanWinNim(n - 5) && CanWinNim(n - 6);
        // return takeOne || takeTwo || takeThree;

        // solution 2: dp
        // dp[i]: for any n, (n-1)%7 = i
        // bool[] dp = new bool[7];
        // Array.Fill(dp, true);
        // dp[3] = false;  // n==4
        // for (int i = 8; i <= n; i++)
        // {
        //     int idx = (i - 1) % 7;
        //     bool takeOne = dp[GetIdx(idx, 2)] && dp[GetIdx(idx, 3)] && dp[GetIdx(idx, 4)];
        //     bool takeTwo = dp[GetIdx(idx, 3)] && dp[GetIdx(idx, 4)] && dp[GetIdx(idx, 5)];
        //     bool takeThree = dp[GetIdx(idx, 4)] && dp[GetIdx(idx, 5)] && dp[GetIdx(idx, 6)];
        //     dp[idx] = takeOne || takeTwo || takeThree;
        // }

        // return dp[(n - 1) % 7];

        // solution 3:
        return n % 4 != 0;
    }

    int GetIdx(int start, int gap)
    {
        return (start - gap + 7) % 7;
    }
}
// @lc code=end

