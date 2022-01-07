using System.Collections.Generic;

namespace LeetCode
{
    public class Mst
    {
        int mstWeight = 0;
        PriorityQueue<(int, int), int> pq;  // store edge (u, v), weight
        bool[] inMst;
        List<(int, int)> mst;
        public int Prim(List<(int nb, int weight)>[] graph){
            int n = graph.Length;
            inMst = new bool[n];
            mst  = new();
            pq = new();
            inMst[0] = true;
            AddEdges(graph, 0);
            while(pq.Count > 0){
                pq.TryDequeue(out var edge, out var weight);
                int v = edge.Item2;
                if (inMst[v]) continue;
                inMst[v] = true;
                mstWeight += weight;
                mst.Add(edge);
                AddEdges(graph, v);
            }

            // check if all nodes in
            for(int i=0; i<n; i++){
                if (!inMst[i])
                    return -1;  // not a tree
            }
            return mstWeight;
        }

        private void AddEdges(List<(int nb, int weight)>[] graph, int v){
            foreach (var (to, weight) in graph[v]){
                if (!inMst[to]){
                    pq.Enqueue((v, to), weight);
                }
            }
        }
    }
}