/*
 * @lc app=leetcode.cn id=685 lang=csharp
 *
 * [685] 冗余连接 II
 */

// @lc code=start
public class Solution
{
    public int[] FindRedundantDirectedConnection(int[][] edges)
    {
        // Build tree using union find
        int n = edges.Length;
        int[] parent = new int[n + 1];
        for (int i = 1; i <= n; i++)
            parent[i] = i;
        var uf = new UnionFind(n + 1);
        int conflict = -1;
        int cycle = -1;
        for (int i = 0; i < n; i++)
        {
            int from = edges[i][0];
            int to = edges[i][1];
            if (parent[to] != to)
                conflict = i;
            else
            {
                parent[to] = from;
                if (uf.Find(from) == uf.Find(to))
                    cycle = i;
                else
                    uf.Union(from, to);
            }
        }

        // find the redundant edge
        if (conflict < 0)
        {
            // only have cycle
            return edges[cycle];
        }
        else
        {
            if (cycle < 0)
            {
                // only have on conflict
                return edges[conflict];
            }
            else
            {
                int conflictTo = edges[conflict][1];
                return new int[] { parent[conflictTo], conflictTo };
            }
        }
    }

    class UnionFind
    {
        int[] ancestor;
        public UnionFind(int n)
        {
            ancestor = new int[n];
            for (int i = 0; i < n; i++)
                ancestor[i] = i;
        }

        public int Find(int x)
        {
            while (x != ancestor[x])
                x = ancestor[x];
            return x;
        }

        public void Union(int from, int to)
        {
            ancestor[Find(to)] = Find(from);
        }
    }
}
// @lc code=end

