using System;
using System.Linq;

namespace LeetCode
{
    // 410: https://leetcode-cn.com/problems/split-array-largest-sum/
    public class SplitArrayMax
    {
        public int SplitArray(int[] nums, int m)
        {
            int left = nums.Max();
            int right = nums.Sum();
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (Split(nums, mid) == m)
                {
                    right = mid - 1;
                }
                else if (Split(nums, mid) < m)
                {
                    right = mid - 1;
                }
                else if (Split(nums, mid) > m)
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        // Given a array and the max of the sub-array sum, return group count
        // This is the reverse problem of the original problem
        // eg: nums=[1,2,3,4], max = 5
        //     return 3, because split into [1,2], [3], [4]
        private int Split(int[] nums, int max)
        {
            int partSum = 0;
            int res = 0;
            foreach (var n in nums)
            {
                partSum += n;
                if (partSum == max)
                {
                    res++;
                    partSum = 0;
                }
                else if (partSum > max)
                {
                    res++;
                    partSum = n;
                }
            }
            return partSum == 0 ? res : res + 1;
        }
    }
}