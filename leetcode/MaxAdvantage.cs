using System;
using System.Linq;

namespace LeetCode
{
    public class MaxAdvantage
    {
        public int[] AdvantageCount(int[] nums1, int[] nums2)
        {
            var orderedNum2 = nums2
                .Select((n, idx) => new { Idx = idx, Val = n })
                .OrderByDescending(vp => vp.Val)
                .ToList();
            Array.Sort(nums1);
            int low = 0;
            int high = nums1.Length - 1;
            int[] res = new int[nums1.Length];
            for (int i = 0; i < orderedNum2.Count; i++)
            {
                var curr = orderedNum2[i];
                if (curr.Val >= nums1[high])
                {
                    res[curr.Idx] = nums1[low];
                    low++;
                }
                else
                {
                    res[curr.Idx] = nums1[high];
                    high--;
                }
            }
            return res;
        }
    }
}

