using System;
/*
 * @lc app=leetcode.cn id=518 lang=csharp
 *
 * [518] 零钱兑换 II
 */

// @lc code=start
public class Solution {
    public int Change(int amount, int[] coins) {
        // dp[i, j] = options when the target amount is j, and the coins is coins[0...i-1]
        int[] dp = new int[amount+1];
        Array.Fill(dp, 0);
        dp[0] = 1;

        for(int i=1; i<=coins.Length; i++){
            for(int j=1; j<= amount; j++){
                if(j - coins[i-1] >= 0)
                    dp[j] = dp[j] + dp[j-coins[i-1]];
            }
        }

        return dp[amount];
    }
}
// @lc code=end

