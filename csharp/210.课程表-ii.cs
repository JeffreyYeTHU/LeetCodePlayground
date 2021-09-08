/*
 * @lc app=leetcode.cn id=210 lang=csharp
 *
 * [210] 课程表 II
 */

// @lc code=start
public class Solution
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        // build graph
        var graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
            graph[i] = new List<int>();
        foreach (var edge in prerequisites)
            graph[edge[1]].Add(edge[0]);

        visited = new bool[numCourses];
        onPath = new bool[numCourses];
        for (int i = 0; i < numCourses; i++)
            Traverse(graph, i);

        if (hasCycle)
            return new int[0];
        else
        {
            var res = new int[numCourses];
            for (int i = postOrder.Count - 1; i >= 0; i--)
                res[postOrder.Count - 1 - i] = postOrder[i];
            return res;
        }
    }

    bool[] visited;
    bool[] onPath;
    bool hasCycle = false;
    List<int> postOrder = new List<int>();
    private void Traverse(List<int>[] graph, int node)
    {
        if (onPath[node])
            hasCycle = true;
        if (visited[node])
            return;

        visited[node] = true;
        onPath[node] = true;
        foreach (var adj in graph[node])
            Traverse(graph, adj);
        postOrder.Add(node);
        onPath[node] = false;
    }
}
// @lc code=end

