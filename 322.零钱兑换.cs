using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=322 lang=csharp
 *
 * [322] 零钱兑换
 */

// @lc code=start
public class Solution {
    public int CoinChange(int[] coins, int amount) {
        int[] dp = new int[amount + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;
        for (int i = 1; i <= amount; i++)
        {
            foreach (var coin in coins)
            {
                if(i - coin >= 0 && dp[i-coin] != -1)
                    dp[i] = Math.Min(dp[i], dp[i-coin] + 1);
            }
            if(dp[i] == int.MaxValue)
                dp[i] = -1;
        }
        foreach (var d in dp)
        {
            Console.Write(d + ", ");
        }
        return dp[amount];
    }
}
// @lc code=end

