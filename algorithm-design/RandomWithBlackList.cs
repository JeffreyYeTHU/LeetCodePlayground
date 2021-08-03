using System;
using System.Collections.Generic;
namespace LeetCode
{
    // 710
    public class RandomWithBlackList
    {
        private int sz;
        private Dictionary<int, int> mapping;
        public RandomWithBlackList(int n, int[] blacklist)
        {
            sz = n - blacklist.Length;
            mapping = new Dictionary<int, int>();
            foreach (var b in blacklist)
            {
                mapping.Add(b, b);
            }

            // map to [0, sz)
            int last = n - 1;
            foreach (var b in blacklist)
            {
                if (b < sz)
                {
                    while (mapping.ContainsKey(last))
                        last--;
                    mapping[b] = last;
                }
            }
        }

        public int Pick()
        {
            var r = new Random().Next() % sz;
            if (mapping.ContainsKey(r))
                return mapping[r];
            else
                return r;
        }

        private void Print(Dictionary<int, int> dic)
        {
            foreach (var item in dic)
            {
                Console.Write($"key={item.Key}, value={item.Value};");
            }
            Console.WriteLine(".");
        }
    }
}