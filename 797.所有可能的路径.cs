/*
 * @lc app=leetcode.cn id=797 lang=csharp
 *
 * [797] 所有可能的路径
 */

// @lc code=start
public class Solution
{
    private IList<IList<int>> paths = new List<IList<int>>();
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        var path = new List<int>();
        Traverse(graph, 0, path);
        return paths;
    }

    private void Traverse(int[][] graph, int node, List<int> path)
    {
        if (node == graph.Length - 1)
        {
            path.Add(node);
            paths.Add(new List<int>(path));
            path.RemoveAt(path.Count - 1);
            return;
        }
        foreach (var n in graph[node])
        {
            path.Add(node);
            Traverse(graph, n, path);
            path.RemoveAt(path.Count - 1);
        }
    }
}
// @lc code=end

