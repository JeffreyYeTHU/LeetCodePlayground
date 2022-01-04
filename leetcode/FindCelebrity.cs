using System.Collections.Generic;

namespace LeetCode
{
    internal class FindCelebrity
    {
        public int FindWithFastRullOut(int n)
        {
            Queue<int> q = new();
            // treat all as candidate
            for (int i = 0; i < n; i++)
                q.Enqueue(i);

            // rull out
            // because only one can be celebraty,
            // and we can easily decide that
            while(q.Count > 1)
            {
                int a = q.Dequeue();
                int b = q.Dequeue();
                if(Knows(a, b) || !Knows(b, a))
                {
                    // a is not
                    q.Enqueue(b);
                }
                else
                {
                    q.Enqueue(a);
                }
            }

            // last cand
            int cand = q.Dequeue();
            for(int other=0; other<n; other++)
            {
                if (cand == other) continue;
                if (Knows(cand, other) || !Knows(other, cand))
                    return -1;
            }
            return cand;
        }

        public int FindWithBrutleForce(int n)
        {
            for(int cand=0; cand<n; cand++)
            {
                int other = 0;
                for(; other < n; other++)
                {
                    if (other == cand) continue;
                    if (Knows(cand, other) || !Knows(other, cand))
                        break;
                }
                if (other == n)
                    return cand;
            }
            return -1;
        }

        private bool Knows(int a, int b)
        {
            return false;
        }
    }
}