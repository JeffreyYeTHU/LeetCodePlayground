/*
 * @lc app=leetcode.cn id=1462 lang=csharp
 *
 * [1462] 课程表 IV
 */

// @lc code=start

    public class Solution
    {
        public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
        {
            // build graph
            List<int>[] graph = new List<int>[numCourses];
            foreach (var edge in prerequisites)
            {
                int from = edge[0];
                int to = edge[1];
                if (graph[from] == null)
                    graph[from] = new List<int>();
                graph[from].Add(to);
            }

            // traverse graph ge build successor sets
            successors = new HashSet<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
                Successor(graph, i);

            // do query
            var res = new List<bool>();
            foreach (var q in queries)
                res.Add(successors[q[0]].Contains(q[1]));
            return res;
        }

        HashSet<int>[] successors;
        // Get successor of the specified start
        private HashSet<int> Successor(List<int>[] graph, int start)
        {
            if (successors[start].Count != 0)
                return successors[start];

            if (graph[start] != null)
            {
                foreach (var adj in graph[start])
                {
                    successors[adj] = Successor(graph, adj);
                    successors[start] = successors[start].Union(successors[adj]).ToHashSet();
                }
            }
            return successors[start];
        }
    }


// @lc code=end

