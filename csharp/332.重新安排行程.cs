/*
 * @lc app=leetcode.cn id=332 lang=csharp
 *
 * [332] 重新安排行程
 */

// @lc code=start
public class Solution
{
    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
        // build tree
        var adj = new Dictionary<string, List<List<string>>>();
        unvisitedCnt = tickets.Count;
        visited = new Dictionary<List<string>, bool>();
        foreach (var t in tickets)
        {
            string from = t[0];
            if (!adj.ContainsKey(from))
                adj.Add(from, new List<List<string>>());
            adj[from].Add(t);
            visited.Add(t, false);
        }

        // Find paths
        TraversePath(adj, "JFK", new List<string>() { "JFK" });
        return MinPath(paths);
    }

    List<List<string>> paths = new List<List<string>>();
    Dictionary<List<string>, bool> visited;
    int unvisitedCnt = 0;
    void TraversePath(Dictionary<string, List<List<string>>> adj, string from, List<string> path)
    {
        // base case
        if (unvisitedCnt == 0)
        {
            path.Add(new List<string>(path));
            return;
        }

        // take one path
        foreach (var ticket in adj[from])
        {
            if (visited[ticket]) continue;
            visited[ticket] = true;
            unvisitedCnt--;
            path.Add(ticket[1]);
            TraversePath(adj, ticket[1], path);
            visited[ticket] = false;
            unvisitedCnt++;
        }
    }

    List<string> MinPath(List<List<string>> paths)
    {

    }
}
// @lc code=end

