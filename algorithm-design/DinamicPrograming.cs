using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

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

        // 931 - minimal path sum
        public int MinFallingPathSum(int[][] matrix)
        {
            int n = matrix.Length;
            if (n == 1) return matrix[0][0];
            int[,] dp = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                dp[n - 1, i] = matrix[n - 1][i];
            }
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = 0; j < n; j++)
                {
                    int leftDown = j == 0 ? int.MaxValue : dp[i + 1, j - 1];
                    int down = dp[i + 1, j];
                    int rightDown = j == n - 1 ? int.MaxValue : dp[i + 1, j + 1];
                    dp[i, j] = Math.Min(leftDown, Math.Min(down, rightDown)) + matrix[i][j];
                }
            }
            return Enumerable.Range(0, n).Select(i => dp[0, i]).Min();
        }

        // 931 using back tracking to find minimal
        public int MinFallingPathSumBt(int[][] matrix)
        {
            int n = matrix.Length;
            memo = new int[n, n];
            for (int i = 0; i < matrix[0].Length; i++)
            {
                int sum = matrix[0][i];
                BacktrackSum(sum, 0, i, matrix);
            }
            return pathSums.Min();
        }

        // 931 - using back tracking to find all path
        private List<List<int>> paths = new List<List<int>>();
        public List<List<int>> AllFallingPathSumBt(int[][] matrix)
        {
            for (int i = 0; i < matrix[0].Length; i++)
            {
                var p = new List<int>();
                p.Add(matrix[0][i]);
                Backtrack(p, 0, i, matrix);
            }
            return paths;
        }

        private void Backtrack(List<int> path, int row, int col, int[][] matrix)
        {
            if (row == matrix.Length - 1)
            {
                paths.Add(new List<int>(path));
                return;
            }

            // make choice
            if (col - 1 >= 0)
            {
                path.Add(matrix[row + 1][col - 1]);
                Backtrack(path, row + 1, col - 1, matrix);
                path.RemoveAt(path.Count - 1);
            }
            path.Add(matrix[row + 1][col]);
            Backtrack(path, row + 1, col, matrix);
            path.RemoveAt(path.Count - 1);
            if (col + 1 < matrix[row].Length)
            {
                path.Add(matrix[row + 1][col + 1]);
                Backtrack(path, row + 1, col + 1, matrix);
                path.RemoveAt(path.Count - 1);
            }
        }

        private List<int> pathSums = new List<int>();
        private int[,] memo;
        private void BacktrackSum(int pathSum, int row, int col, int[][] matrix)
        {
            if (row == matrix.Length - 1)
            {
                pathSums.Add(pathSum);
                return;
            }

            // make choice
            if (col - 1 >= 0)
            {
                pathSum += matrix[row + 1][col - 1];
                BacktrackSum(pathSum, row + 1, col - 1, matrix);
                pathSum -= matrix[row + 1][col - 1];
            }
            pathSum += matrix[row + 1][col];
            BacktrackSum(pathSum, row + 1, col, matrix);
            pathSum -= matrix[row + 1][col];
            if (col + 1 < matrix[row].Length)
            {
                pathSum += matrix[row + 1][col + 1];
                BacktrackSum(pathSum, row + 1, col + 1, matrix);
                pathSum -= matrix[row + 1][col + 1];
            }
        }
    }
}