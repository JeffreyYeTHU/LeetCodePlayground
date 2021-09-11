/*
 * @lc app=leetcode.cn id=514 lang=csharp
 *
 * [514] 自由之路
 */

// @lc code=start
public class Solution
{
    public int FindRotateSteps(string ring, string key)
    {
        // build dic
        int m = ring.Length;
        int n = key.Length;
        var varToIdx = new Dictionary<char, List<int>>();
        for (int i = 0; i < m; i++)
        {
            if (!varToIdx.ContainsKey(ring[i]))
                varToIdx.Add(ring[i], new List<int>());
            varToIdx[ring[i]].Add(i);
        }

        // dp[i, j] = start from ring[i], the min steps to key[j..n-1]
        int[,] dp = new int[m, n + 1];
        for (int i = 0; i < m; i++)
            dp[i, n] = 0;
        for (int j = n - 1; j >= 0; j--)
        {
            for (int i = 0; i < m; i++)
            {
                List<int> kIdx = varToIdx[key[j]];
                var disToK = kIdx
                    .Select(idx =>
                    {
                        int d = i - idx > 0 ? i - idx : idx - i;  // d >=0
                        return Math.Min(d, m - d) + 1 + dp[idx, j + 1];
                    })
                    .ToList();
                dp[i, j] = disToK.Min();
            }
        }
        return dp[0, 0];
    }

    void Print(int[,] dp)
    {
        Console.WriteLine("dp=");
        for (int i = 0; i < dp.GetLength(0); i++)
        {
            for (int j = 0; j < dp.GetLength(1); j++)
            {
                Console.Write(dp[i, j] + ", ");
            }
            Console.WriteLine();
        }
    }
}
// @lc code=end

