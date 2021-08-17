using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
            var sortedData = new SortedList<int, int>();  // make value=key
            int[] dp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (!sortedData.ContainsKey(nums[i]))
                    sortedData.Add(nums[i], nums[i]);
                dp[i] = sortedData.IndexOfKey(nums[i]) + 1;
            }
            Console.WriteLine(dp);
        }
    }
}
