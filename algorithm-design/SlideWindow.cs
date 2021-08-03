using System;
using System.Collections.Generic;

namespace LeetCode
{
    public sealed class SlideWindow
    {
        // 239 滑动窗口最大值
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var window = new SortedDictionary<int, int>(new MyComparer());
            int left = 0;
            int right = 0;
            var res = new List<int>();
            while (right < nums.Length)
            {
                // enlarge window
                int a = nums[right];
                right++;
                if (!window.ContainsKey(a))
                    window.Add(a, 1);
                else
                    window[a]++;

                while (right - left >= k)
                {
                    // add max
                    var iter = window.GetEnumerator();
                    iter.MoveNext();
                    res.Add(iter.Current.Key);

                    // shrink window
                    int d = nums[left];
                    left++;
                    window[d]--;
                    if (window[d] == 0)
                        window.Remove(d);
                }
            }
            return res.ToArray();
        }

        private class MyComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y - x;
            }
        }
    }
}