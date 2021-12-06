using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //SortAlgoTest();
        }

        // Problem 651 is not available in LeetCode, so I write my own
        private static int Problem651(int n)
        {
            // dp[i] : for i operations, the max A's can get
            if (n <= 6)
                return n;
            int[] dp = new int[n + 1];
            dp[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                dp[i] = dp[i - 1] + 1;  // just insert A
                for (int j = i - 3; j >= 2; j--)
                {
                    dp[i] = Math.Max(dp[i], dp[j] * (i - j - 3 + 1));
                }
            }
            return dp[n];
        }

        private static void SortAlgoTest()
        {
            int[] arr = new int[] { 2, 5, 3, 1, 4 };
            var sroter = new Sorter();

            // bubble sort, and quick sort
            // sroter.BubbleSort(arr);
            // sroter.QuickSort(arr, 0, arr.Length - 1);

            // insert sort
            // sroter.InsertSort(arr);
            // sroter.ShellSort(arr);

            // select sort
            // sroter.SelectSort(arr);

            // heap sort
            // sroter.HeapSort(arr);

            // merger sort
            var res = sroter.MergeSort(arr);
        }
    }
}