using System;
using System.Collections.Generic;

namespace LeetCode
{
    internal class DelayTime
    {
        public int Dijkstra(int[][] times, int n, int k)
        {
            // build graph
            Dictionary<int, int>[] graph = new Dictionary<int, int>[n+1];
            for (int i = 1; i <= n; i++)
                graph[i] = new Dictionary<int, int>();
            foreach (var edge in times)
            {
                int from = edge[0];
                int to = edge[1];
                int time = edge[2];
                graph[from].Add(to, time);
            }

            // find minmal route
            int[] distTo = new int[n+1];  // do not use index 0
            Array.Fill(distTo, int.MaxValue);
            distTo[k] = 0;
            PriorityQueue<int, int> pq = new();
            pq.Enqueue(k, 0);
            while (pq.Count > 0)
            {
                int currNode, disToCurr;
                pq.TryDequeue(out currNode, out disToCurr);
                if (disToCurr > distTo[currNode])
                    continue;

                distTo[currNode] = disToCurr;
                foreach (var nb in graph[currNode])
                {
                    int nextNode = nb.Key;
                    int edgeWeight = nb.Value;
                    int disToNext = disToCurr + edgeWeight;
                    if (disToNext < distTo[nextNode])
                        pq.Enqueue(nextNode, disToNext);
                }
            }

            // check the minimal
            int res = 0;
            for (int i = 1; i <= n; i++)
            {
                if (distTo[i] == int.MaxValue)
                    return -1;
                res = Math.Max(res, distTo[i]);
            }
            return res;
        }

        public int BellFord(int[][] times, int n, int k)
        {
            int[] distTo = new int[n+1];  // do not use index 0
            Array.Fill(distTo, int.MaxValue);
            distTo[k] = 0;
            for(int i = 0; i < n-1; i++)
            {
                foreach(var edge in times)
                {
                    int from = edge[0];
                    int to = edge[1];
                    int weight = edge[2];
                    distTo[to] = Math.Min(distTo[from] + weight, distTo[to]);
                }
            }

            int res = 0;
            for(int i=1; i<=n; i++)
            {
                if (distTo[i] == int.MaxValue)
                    return -1;
                res = Math.Max(res, distTo[i]);
            }
            return res;
        }
    }
}