namespace LeetCode
{
    public class DinamicPrograming
    {
        // 509
        public int Fib(int n)
        {
            int pre = 0;
            int curr = 1;
            if (n == 0) return 0;
            if (n == 1) return 1;
            int res = 0;
            for (int i = 2; i <= n; i++)
            {
                res = pre + curr;
                curr = res;
                pre = curr;
            }
            return res;
        }

        // 322
        public int CoinChange(int[] coins, int amount)
        {
            // base case
            if (amount == 0) return 0;
            int[] dp = new int[amount + 1];
            dp[0] = 0;
            for (int i = 1; i <= amount; i++)
                dp[i] = amount + 1;

            // do state transfer
            for (int i = 1; i <= amount; i++)
            {
                foreach (int coin in coins)
                {
                    if (i - coin < 0) continue;
                    dp[i] = System.Math.Min(dp[i], 1 + dp[i - coin]);
                }
            }

            return dp[amount] == amount + 1 ? -1 : dp[amount];
        }
    }
}