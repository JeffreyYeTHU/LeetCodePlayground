package leetcode;

import java.util.LinkedList;
import java.util.List;

public class Graph {

    public List<List<Integer>> allPathsSourceTarget(int[][] graph) {
        LinkedList<Integer> path = new LinkedList<>();
        traverse(graph, 0, path);
        return res;
    }

    List<List<Integer>> res = new LinkedList<>();

    private void traverse(int[][] graph, int s, LinkedList<Integer> path) {
        path.addLast(s);

        int n = graph.length;
        if (s == n - 1) {
            res.add(new LinkedList<>(path));
            return;
        }

        for (int neighbor : graph[s]) {
            traverse(graph, neighbor, path);
        }

        path.removeLast();
    }
}
