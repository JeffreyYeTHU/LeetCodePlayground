/*
 * @lc app=leetcode.cn id=399 lang=csharp
 *
 * [399] 除法求值
 */

// @lc code=start
public class Solution
{
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        // // Solution 1: dfs
        // // Regard it as a directed graph
        // var graph = BuildGraph(equations, values);

        // // do dfs
        // double[] res = new double[queries.Count];
        // for (int i = 0; i < queries.Count; i++)
        // {
        //     var from = queries[i][0];
        //     var to = queries[i][1];
        //     visited.Clear();
        //     res[i] = Dfs(graph, from, to, 1.0);
        // }
        // return res;

        // solution 2: bfs
        var graph = BuildGraph(equations, values);
        double[] res = new double[queries.Count];
        for (int i = 0; i < queries.Count; i++)
        {
            var from = queries[i][0];
            var to = queries[i][1];
            visited.Clear();
            res[i] = Bfs(graph, from, to);
        }
        return res;
    }

    Dictionary<string, List<(string, double)>> BuildGraph(IList<IList<string>> equations, double[] values)
    {
        var graph = new Dictionary<string, List<(string, double)>>();
        for (int i = 0; i < equations.Count; i++)
        {
            var from = equations[i][0];
            var to = equations[i][1];
            var val = values[i];
            if (!graph.ContainsKey(from))
                graph.Add(from, new List<(string, double)>());
            if (!graph.ContainsKey(to))
                graph.Add(to, new List<(string, double)>());
            graph[from].Add((to, val));
            graph[to].Add((from, 1 / val));
        }
        return graph;
    }

    HashSet<string> visited = new HashSet<string>();
    double Dfs(Dictionary<string, List<(string, double)>> graph, string from, string to, double path)
    {
        if (!graph.ContainsKey(from) || !graph.ContainsKey(to))
            return -1.0;
        if (from == to)
            return path;

        visited.Add(from);
        foreach (var (nb, val) in graph[from])
        {
            if (!visited.Contains(nb))
            {
                double p = Dfs(graph, nb, to, path * val);
                if ((int)p != -1)
                    return p;
            }
        }
        return -1.0;
    }

    double Bfs(Dictionary<string, List<(string, double)>> graph, string from, string to)
    {
        if (!graph.ContainsKey(from) || !graph.ContainsKey(to))
            return -1.0;
        var q = new Queue<State>();
        q.Enqueue(new State() { NodeId = from, DisToCurr = 1.0 });
        visited.Add(from);
        while (q.Count > 0)
        {
            var curr = q.Dequeue();
            if (curr.NodeId == to)
                return curr.DisToCurr;
            foreach (var (nb, val) in graph[curr.NodeId])
            {
                if (!visited.Contains(nb))
                {
                    visited.Add(nb);
                    q.Enqueue(new State() { NodeId = nb, DisToCurr = curr.DisToCurr * val });
                }
            }
        }
        return -1.0;
    }

    private class State
    {
        public string NodeId { get; set; }
        public double DisToCurr { get; set; }
    }
}
// @lc code=end

