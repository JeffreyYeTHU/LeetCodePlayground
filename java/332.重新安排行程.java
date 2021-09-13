import java.awt.List;
import java.util.Collection;
import java.util.Collections;
import java.util.Map;
import java.util.PriorityQueue;

/*
 * @lc app=leetcode.cn id=332 lang=java
 *
 * [332] 重新安排行程
 */

// @lc code=start
class Solution {
    List<String> itinerary = new LinkedList<String>();
    Map<String, PriorityQueue<String>> map = new HashMap<String, PriorityQueue<String>>();

    public List<String> findItinerary(List<List<String>> tickets) {
        // build tree
        for (List<String> ticket : tickets) {
            String src = ticket.get(0);
            String dst = ticket.get(1);
            if (!map.containsKey(src))
                map.put(src, new PriorityQueue<String>());
            map.get(src).offer(dst);
        }

        // do dfs
        dfs("JFK");
        Collections.reverse(itinerary);
        return itinerary;
    }

    void dfs(String curr) {
        while (map.containsKey(curr) && map.get(curr).size() > 0) {
            dfs(map.get(curr).poll());
        }
        itinerary.add(curr);
    }
}
// @lc code=end
