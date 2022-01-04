using System;
using System.Collections.Generic;

namespace algorithm_design
{
    public class ShortestPath
    {
        public int Dijkstra(List<(int nb, int w)>[] graph, int s, int t)
        {
            int n = graph.Length;
            PriorityQueue<int, int> q = new();
            bool[] visited = new bool[n];
            int[] distance = new int[n];
            Array.Fill(distance, int.MaxValue);
            q.Enqueue(s, 0);
            while(q.Count != 0)
            {
                q.TryDequeue(out int currNode, out int disToCurr);
                visited[currNode] = true;
                if (distance[currNode] < disToCurr) continue;
                distance[currNode] = disToCurr;
                foreach (var (nb, w) in graph[currNode])
                {
                    int disToNext = disToCurr + w;
                    if(!visited[nb] && distance[nb] > disToNext)
                    {
                        q.Enqueue(nb, disToNext);
                    }
                }
            }
            return distance[t];
        }

        public int DijkstraImprove(List<(int nb, int w)>[] graph, int s, int t)
        {
            int n = graph.Length;
            PriorityQueue<int, int> q = new();
            int[] distance = new int[n];
            Array.Fill(distance, int.MaxValue);
            q.Enqueue(s, 0);
            while (q.Count != 0)
            {
                q.TryDequeue(out int currNode, out int disToCurr);
                if (distance[currNode] < disToCurr) continue;
                distance[currNode] = disToCurr;
                foreach (var (nb, w) in graph[currNode])
                {
                    int disToNext = disToCurr + w;
                    if (distance[nb] > disToNext)
                    {
                        q.Enqueue(nb, disToNext);
                    }
                }
            }
            return distance[t];
        }

        public int BellFord(List<(int nb, int w)>[] graph, int s, int t)
        {
            int n = graph.Length;
            int[] distance = new int[n];
            Array.Fill(distance, int.MaxValue);
            distance[s] = 0;
            for(int i=0; i<n - 1; i++)
            {
                // check all edges
                for(int j=0; j<n; j++)
                {
                    if(distance[j] != int.MaxValue)
                    {
                        foreach (var (nb, w) in graph[j])
                        {
                            distance[nb] = Math.Min(distance[nb], distance[j] + w);
                        }
                    }
                }
            }

            // check for neg-loop
            for(int j=0; j<n; j++)
            {
                foreach(var (nb, w) in graph[j])
                {
                    if (distance[j] + w < distance[nb])
                        return -1;
                }
            }

            return distance[t];
        }
    }
}
