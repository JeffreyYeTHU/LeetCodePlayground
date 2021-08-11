/*
 * @lc app=leetcode.cn id=72 lang=csharp
 *
 * [72] 编辑距离
 */

// @lc code=start
public class Solution
{
    public int MinDistance(string word1, string word2)
    {
        // Solution 1: recursive with memo
        // memo = new Dictionary<(int, int), int>();
        // return Dp(word1, word2, word1.Length - 1, word2.Length - 1);

        // Solution 2: dp
        // dp[i, j] is the edit length of s[0...i-1] and t[0...j-1]
        int m = word1.Length;
        int n = word2.Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; i++)
            dp[i, 0] = i;
        for (int j = 1; j <= n; j++)
            dp[0, j] = j;
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (word1[i - 1] == word2[j - 1])
                    dp[i, j] = dp[i - 1, j - 1];
                else
                {
                    dp[i, j] = Min(
                                 dp[i - 1, j - 1] + 1,  // replace
                                 dp[i - 1, j] + 1,  // delete
                                 dp[i, j - 1] + 1  // insert
                             );
                }

            }
        }
        return dp[m, n];
    }

    // Get minimal distance between s[0...i] and t[0...j]
    Dictionary<(int, int), int> memo;
    private int Dp(string s, string t, int i, int j)
    {
        if (i == -1) return j + 1;
        if (j == -1) return i + 1;

        if (memo.ContainsKey((i, j)))
            return memo[(i, j)];

        if (s[i] == t[j])
        {
            memo[(i, j)] = Dp(s, t, i - 1, j - 1);
            return memo[(i, j)];
        }
        else
        {
            memo[(i, j)] = Min(
                 Dp(s, t, i - 1, j) + 1,  // delete
                 Dp(s, t, i, j - 1) + 1,  // insert
                 Dp(s, t, i - 1, j - 1) + 1  // replace
             );
            return memo[(i, j)];
        }
    }

    private int Min(int a, int b, int c)
    {
        return Math.Min(a, Math.Min(b, c));
    }
}
// @lc code=end

