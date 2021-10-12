import java.util.PriorityQueue;

/*
 * @lc app=leetcode.cn id=871 lang=java
 *
 * [871] 最低加油次数
 */

// @lc code=start
class Solution {
    public int minRefuelStops(int target, int startFuel, int[][] stations) {
        PriorityQueue<Integer> pq = new PriorityQueue<>((a, b) -> {
            return b - a;
        });
        int tank = startFuel;
        int ans = 0;
        int prev = 0;
        for (int[] station : stations) {
            int loc = station[0];
            int cap = station[1];
            tank = tank - (loc - prev);
            while (!pq.isEmpty() && tank < 0) {
                tank += pq.poll();
                ans++;
            }
            if (tank < 0)
                return -1;
            pq.offer(cap);
            prev = loc;
        }

        // repeat body for target
        tank = tank - (target - prev);
        while (!pq.isEmpty() && tank < 0) {
            tank += pq.poll();
            ans++;
        }
        return tank < 0 ? -1 : ans;
    }
}
// @lc code=end
