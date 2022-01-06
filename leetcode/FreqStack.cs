using System;
using System.Collections.Generic;
namespace LeetCode
{
    public class FreqStack
    {
        Dictionary<int, int> valToFreq;
        Dictionary<int, Stack<int>> freqToVals;  // if a val have freq > 1, it will show up in mutiple stacks
        int maxFreq;
        public FreqStack()
        {
            maxFreq = 0;
            valToFreq = new();
            freqToVals = new();
        }

        public void Push(int val)
        {
            int newfreq;
            if (valToFreq.ContainsKey(val))
            {
                valToFreq[val]++;
                newfreq = valToFreq[val];
            }
            else
            {
                valToFreq.Add(val, 1);
                newfreq = 1;
            }
            if (!freqToVals.ContainsKey(newfreq))
                freqToVals.Add(newfreq, new Stack<int>());
            freqToVals[newfreq].Push(val);
            maxFreq = Math.Max(maxFreq, newfreq);
        }

        public int Pop()
        {
            var vals = freqToVals[maxFreq];
            int res = vals.Pop();
            valToFreq[res]--;
            if(vals.Count == 0)
            {
                maxFreq--;
            }
            return res;
        }
    }
}
