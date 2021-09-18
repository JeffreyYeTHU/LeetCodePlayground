import java.util.Map;
import java.util.Set;

/*
 * @lc app=leetcode.cn id=1207 lang=java
 *
 * [1207] 独一无二的出现次数
 */

// @lc code=start
class Solution {
    public boolean uniqueOccurrences(int[] arr) {
        Map<Integer, Integer> map = new HashMap<>();
        for (int a : arr) {
            if (map.containsKey(a))
                map.put(a, map.get(a) + 1);
            else
                map.put(a, 1);
        }
        Set<Integer> set = new HashSet<>();
        for (int cnt : map.values()) {
            if (set.contains(cnt))
                return false;
            else
                set.add(cnt);
        }
        return true;
    }
}
// @lc code=end
