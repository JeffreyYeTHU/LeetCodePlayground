/*
 * @lc app=leetcode.cn id=204 lang=csharp
 *
 * [204] 计数质数
 */

// @lc code=start
public class Solution
{
    public int CountPrimes(int n)
    {
        // solution 1:
        // if (n <= 2) return 0;
        // int res = 1;
        // for (int i = 3; i < n; i++)
        // {
        //     if (IsPrime(i))
        //         res++;
        // }
        // return res;

        // solution 2:
        bool[] isPrime = new bool[n];
        Array.Fill(isPrime, true);
        for (int i = 2; i * i < n; i++)
        {
            for (int j = i * i; j < n; j += i)
                isPrime[j] = false;
        }

        int cnt = 0;
        for (int i = 2; i < n; i++)
        {
            if (isPrime[i])
                cnt++;
        }
        return cnt;
    }

    bool IsPrime(int n)
    {
        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }
}
// @lc code=end

