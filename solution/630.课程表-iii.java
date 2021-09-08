import java.util.PriorityQueue;

/*
 * @lc app=leetcode.cn id=630 lang=java
 *
 * [630] 课程表 III
 */

// @lc code=start
class Solution {
    public int scheduleCourse(int[][] courses) {
        Arrays.sort(courses, (a, b) -> a[1] - b[1]);
        PriorityQueue<Integer> q = new PriorityQueue<Integer>((a, b) -> b - a);
        int time = 0;
        for (int[] c : courses) {
            if (time + c[0] <= c[1]) {
                q.offer(c[0]);
                time += c[0];
            } else if (!q.isEmpty() && q.peek() > c[0]) {
                time = time - q.peek() + c[0];
                q.poll();
                q.offer(c[0]);
            }
        }
        return q.size();
    }
}
// @lc code=end
