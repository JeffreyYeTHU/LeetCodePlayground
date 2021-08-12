using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class Course4
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
                successors[i] = new HashSet<int>();
            for (int i = 0; i < numCourses; i++)
                successors[i] = FindSuccessor(graph, i);

            // do query
            var res = new List<bool>();
            foreach (var q in queries)
                res.Add(successors[q[0]].Contains(q[1]));
            return res;
        }

        HashSet<int>[] successors;
        // Get successor of the specified start
        private HashSet<int> FindSuccessor(List<int>[] graph, int start)
        {
            if (successors[start].Count != 0)
                return successors[start];

            if (graph[start] != null)
            {
                foreach (var adj in graph[start])
                {
                    successors[start].Add(adj);
                    successors[adj] = FindSuccessor(graph, adj);
                    successors[start] = successors[start].Union(successors[adj]).ToHashSet();
                }
            }
            return successors[start];
        }
    }
}
    