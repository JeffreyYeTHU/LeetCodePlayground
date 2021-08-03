using System;
using System.Collections.Generic;

namespace LeetCode
{
    // 380
    public class RandomizedSet
    {
        private List<int> data;
        private Dictionary<int, int> valToIdx;
        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            data = new List<int>();
            valToIdx = new Dictionary<int, int>();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (valToIdx.ContainsKey(val))
                return false;
            data.Add(val);
            valToIdx.Add(val, data.Count - 1);
            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!valToIdx.ContainsKey(val))
                return false;
            int len = data.Count;
            if (valToIdx[val] != len - 1)
            {
                // swap to the last
                int last = data[len - 1];
                data[len - 1] = val;
                data[valToIdx[val]] = last;
                valToIdx[last] = valToIdx[val];
            }
            data.RemoveAt(len - 1);
            valToIdx.Remove(val);
            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            var r = new Random().Next() % (data.Count);
            return data[r];
        }

        private void Print(List<int> data)
        {
            foreach (var d in data)
            {
                Console.Write($"{d},");
            }
            Console.WriteLine();
        }

        private void Print(Dictionary<int, int> valToIdx)
        {
            foreach (var item in valToIdx)
            {
                Console.Write($"key={item.Key}, idx={item.Value},");
            }
            Console.WriteLine();
        }
    }
}