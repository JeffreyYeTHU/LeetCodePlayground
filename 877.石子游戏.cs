/*
 * @lc app=leetcode.cn id=877 lang=csharp
 *
 * [877] 石子游戏
 */

// @lc code=start
public class Solution
{
    public bool StoneGame(int[] piles)
    {
        // solution 1:
        // int half = piles.Sum() / 2;
        // return Dp(piles, 0, piles.Length - 1) > half;

        // solution 2:
        return true;
    }

    // Dp[i, j] = max of piles[i..j]
    Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
    int Dp(int[] piles, int i, int j)
    {
        if (i > j) return 0;
        if (memo.ContainsKey((i, j)))
            return memo[(i, j)];
        int res = Max(
            Dp(piles, i + 2, j) + piles[i],
            Dp(piles, i, j - 2) + piles[j],
            Dp(piles, i + 1, j - 1) + Math.Max(piles[i], piles[j])
        );
        memo.Add((i, j), res);
        return memo[(i, j)];
    }

    int Max(int a, int b, int c)
    {
        return Math.Max(a, Math.Max(b, c));
    }
}
// @lc code=end

