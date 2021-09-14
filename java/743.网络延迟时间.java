import java.util.HashMap;
import java.util.LinkedList;
import java.util.PriorityQueue;

/*
 * @lc app=leetcode.cn id=743 lang=java
 *
 * [743] 网络延迟时间
 */

// @lc code=start
class Solution {
    private List<int[]>[] graph;

    public int networkDelayTime(int[][] times, int n, int k) {
        // build graph
        graph = new LinkedList[n + 1]; // do not use index 0
        for (int i = 1; i <= n; i++) {
            graph[i] = new LinkedList<int[]>();
        }
        for (int[] edge : times) {
            int src = edge[0];
            int dst = edge[1];
            int w = edge[2];
            graph[src].add(new int[] { dst, w });
        }

        // digkstra
        int[] disTo = new int[n + 1]; // do not use index 0
        Arrays.fill(disTo, Integer.MAX_VALUE);
        PriorityQueue<State> pq = new PriorityQueue<>((a, b) -> a.disToNode - b.disToNode);
        pq.offer(new State(k, 0));
        disTo[k] = 0;
        while (!pq.isEmpty()) {
            State curr = pq.poll();
            int currNodeId = curr.nodeId;
            int disToCurrNode = curr.disToNode;
            if (disToCurrNode > disTo[currNodeId]) {
                continue;
            }
            for (int[] nb : graph[currNodeId]) {
                int nextId = nb[0];
                int disToNextId = disTo[currNodeId] + nb[1];
                if (disToNextId < disTo[nextId]) {
                    disTo[nextId] = disToNextId;
                    pq.offer(new State(nextId, disToNextId));
                }
            }
        }
        int res = 0;
        for (int i = 1; i <= n; i++) {
            int dis = disTo[i];
            if (dis == Integer.MAX_VALUE)
                return -1;
            res = Math.max(res, dis);
        }
        return res;
    }

    private class State {
        public int nodeId;
        public int disToNode;

        public State(int nodeId, int disToNode) {
            this.nodeId = nodeId;
            this.disToNode = disToNode;
        }
    }
}
// @lc code=end
