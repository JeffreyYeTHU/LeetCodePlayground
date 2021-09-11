/*
 * @lc app=leetcode.cn id=310 lang=csharp
 *
 * [310] 最小高度树
 */

// @lc code=start
public class Solution
{
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        // // IDEA 1: build the graph, and the compute height of each tree.
        // // The probrem of this method is that it will take to long
        // if (edges.Length == 0)
        //     return new List<int> { 0 };

        // // build tree adjacent link list
        // var adj = new List<int>[n];
        // foreach (var edge in edges)
        // {
        //     int v1 = edge[0];
        //     int v2 = edge[1];
        //     if (adj[v1] == null)
        //         adj[v1] = new List<int>();
        //     if (adj[v2] == null)
        //         adj[v2] = new List<int>();
        //     adj[v1].Add(v2);
        //     adj[v2].Add(v1);
        // }

        // // get all height
        // int[] heights = new int[n];
        // for (int i = 0; i < n; i++)
        //     heights[i] = HeightOf(i, adj, -1);
        // int minHeight = heights.Min();
        // var res = new List<int>();
        // for (int i = 0; i < heights.Length; i++)
        // {
        //     if (heights[i] == minHeight)
        //         res.Add(i);
        // }
        // return res;

        // IDEA 2: The tree with min height must start with node that in the 
        // middle of the graph. so we use BFS to cut leaf form outside
        var res = new List<int>();
        if (edges.Length == 0)
        {
            res.Add(0);
            return res;
        }

        // build tree
        var adj = new List<int>[n];
        var degree = new int[n];
        foreach (var edge in edges)
        {
            int v1 = edge[0];
            int v2 = edge[1];
            if (adj[v1] == null)
                adj[v1] = new List<int>();
            if (adj[v2] == null)
                adj[v2] = new List<int>();
            adj[v1].Add(v2);
            adj[v2].Add(v1);
            degree[v1]++;
            degree[v2]++;
        }

        // Do multi-point BFS
        var q = new Queue<int>();
        for (int i = 0; i < degree.Length; i++)
        {
            if (degree[i] == 1)
                q.Enqueue(i);
        }
        while (q.Count != 0)
        {
            res = new List<int>();
            int cnt = q.Count;
            while (cnt > 0)
            {
                int curr = q.Dequeue();
                res.Add(curr);

                // // Option 1: sue degree to track the graph trim
                // foreach (int nb in adj[curr])
                // {
                //     degree[nb]--;
                //     if (degree[nb] == 1)
                //         q.Enqueue(nb);
                // }

                // Option 2: use adj to track graph trim
                if (adj[curr].Count != 0)
                {
                    int nb = adj[curr][0];
                    adj[curr].Remove(nb);
                    adj[nb].Remove(curr);
                    if (adj[nb].Count == 1)
                        q.Enqueue(nb);
                }

                cnt--;
            }
        }
        return res;
    }

    // Height of tree i, using DFS
    int HeightOf(int i, List<int>[] adj, int parent)
    {
        // when parent is the only connection
        if (adj[i].Count == 1 && parent == adj[i][0])
            return 0;

        int maxHeight = 0;
        foreach (var nb in adj[i])
        {
            if (nb != parent)
            {
                int h = 1 + HeightOf(nb, adj, i);
                if (h > maxHeight)
                    maxHeight = h;
            }
        }
        return maxHeight;
    }

    void PrintAdj(List<int>[] adj)
    {
        Console.WriteLine("adj:");
        for (int i = 0; i < adj.Length; i++)
        {
            Console.Write($"adj[{i}]=");
            foreach (var nb in adj[i])
            {
                Console.Write($"{nb}, ");
            }
            Console.WriteLine();
        }
    }

    void PrintHeights(int[] heights)
    {
        Console.WriteLine("Heights=");
        for (int i = 0; i < heights.Length; i++)
        {
            Console.Write(heights[i] + ", ");
        }
        Console.WriteLine();
    }
}

// @lc code=end

