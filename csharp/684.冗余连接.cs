/*
 * @lc app=leetcode.cn id=684 lang=csharp
 *
 * [684] 冗余连接
 */

// @lc code=start
public class Solution
{
    // Find the path with a circle, then examing this path
    public int[] FindRedundantConnection(int[][] edges)
    {
        // Solution 1: dfs
        // int n = edges.Length;
        // var graph = new List<int>[n + 1];  // do not us graph[0]
        // Dictionary<(int, int), int> edgeToIdx = new Dictionary<(int, int), int>();
        // for (int i = 1; i < n + 1; i++)
        //     graph[i] = new List<int>();
        // for (int i = 0; i < n; i++)
        // {
        //     int from = edges[i][0];
        //     int to = edges[i][1];
        //     graph[from].Add(to);
        //     graph[to].Add(from);
        //     edgeToIdx.Add((from, to), i);
        // }
        // visited = new bool[n + 1]; // do not use visited[0]
        // onPath = new bool[n + 1];  // do not use onPath[0]
        // Dfs(graph, 1, new List<int>());
        // int tag = roundPath[roundPath.Count - 1];
        // int res = -1;
        // for (int i = roundPath.Count - 2; i >= 0; i--)
        // {
        //     int a = Math.Min(roundPath[i], roundPath[i + 1]);
        //     int b = Math.Max(roundPath[i], roundPath[i + 1]);
        //     if (edgeToIdx[(a, b)] > res)
        //         res = edgeToIdx[(a, b)];
        //     if (roundPath[i] == tag)
        //         break;
        // }
        // return edges[res];

        // // solution 2: union find
        // int cnt = edges.Length;
        // int[] parent = new int[cnt + 1];
        // for (int i = 1; i <= cnt; i++)
        // {
        //     parent[i] = i;
        // }
        // for (int i = 0; i < cnt; i++)
        // {
        //     var edge = edges[i];
        //     int node1 = edge[0];
        //     int node2 = edge[1];
        //     if (Find(parent, node1) != Find(parent, node2))
        //         Union(parent, node1, node2);
        //     else
        //         return edge;
        // }
        // return new int[0];

        // Union-find: another implementation
        int n = edges.Length;
        size = new int[n + 1];
        parent = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            parent[i] = i;
            size[i] = 1;
        }
        for (int i = 0; i < n; i++)
        {
            int[] edge = edges[i];
            if (Connected(edge[0], edge[1]))
                return edge;
            else
                Union(edge[0], edge[1]);
        }
        return new int[0];
    }

    bool[] visited;
    bool[] onPath;
    List<int> roundPath;
    bool getCycle;
    int level = 0;
    void Dfs(List<int>[] graph, int s, List<int> path)
    {
        if (onPath[s] && path.Count >= 2 && path[path.Count - 2] != s)
        {
            getCycle = true;
            roundPath = new List<int>(path);
            roundPath.Add(s);
        }
        if (visited[s] || getCycle)
            return;

        visited[s] = true;
        onPath[s] = true;
        path.Add(s);
        foreach (var nb in graph[s])
        {
            Dfs(graph, nb, path);
        }
        path.RemoveAt(path.Count - 1);
        onPath[s] = false;
    }

    void Union(int[] parent, int idx1, int idx2)
    {
        parent[Find(parent, idx1)] = Find(parent, idx2);
    }

    int Find(int[] parent, int idx)
    {
        if (parent[idx] != idx)
        {
            parent[idx] = Find(parent, parent[idx]);
        }
        return parent[idx];
    }

    int[] size;
    int[] parent;
    int count;
    void Union(int p, int q)
    {
        int rootP = Find(p);
        int rootQ = Find(q);
        if (rootP == rootQ)
            return;
        if (size[rootP] < size[rootQ])
        {
            parent[rootP] = rootQ;
            size[rootQ] += size[rootP];
        }
        else
        {
            parent[rootQ] = rootP;
            size[rootP] += size[rootQ];
        }
        count--;
    }

    bool Connected(int p, int q)
    {
        return Find(p) == Find(q);
    }

    int Find(int p)
    {
        while (p != parent[p])
        {
            parent[p] = parent[parent[p]];
            p = parent[p];
        }
        return parent[p];
    }
}
// @lc code=end

