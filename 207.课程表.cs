/*
 * @lc app=leetcode.cn id=207 lang=csharp
 *
 * [207] 课程表
 */

// @lc code=start
public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        // build graph
        List<int>[] graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
            graph[i] = new List<int>();
        foreach (var edge in prerequisites)
            graph[edge[1]].Add(edge[0]);

        // traverse
        visited = new bool[numCourses];
        onPath = new bool[numCourses];
        for (int i = 0; i < numCourses; i++)
            Traverse(graph, i);
        return !hasCycle;
    }

    bool[] visited;
    bool[] onPath;
    bool hasCycle = false;
    private void Traverse(List<int>[] graph, int node)
    {
        if (onPath[node] == true)
            hasCycle = true;

        if (visited[node])
            return;

        visited[node] = true;
        onPath[node] = true;
        foreach (var adj in graph[node])
        {
            Traverse(graph, adj);
        }
        onPath[node] = false;
    }
}
// @lc code=end

