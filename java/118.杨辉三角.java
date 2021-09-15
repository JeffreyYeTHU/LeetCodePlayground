import java.util.ArrayList;
import java.util.List;

import org.graalvm.compiler.nodes.ReturnNode;

/*
 * @lc app=leetcode.cn id=118 lang=java
 *
 * [118] 杨辉三角
 */

// @lc code=start
class Solution {
    public List<List<Integer>> generate(int numRows) {
        ArrayList<List<Integer>> res = new ArrayList<>();
        List<Integer> first = new ArrayList<Integer>();
        first.add(1);
        List<Integer> second = new ArrayList<Integer>();
        second.add(1);
        second.add(1);
        res.add(first);
        if (numRows == 1)
            return res;
        res.add(second);
        if (numRows == 2)
            return res;
        for (int i = 2; i < numRows; i++) {
            List<Integer> curr = new ArrayList<Integer>();
            curr.add(1);
            List<Integer> last = res.get(res.size() - 1);
            for (int j = 0; j < last.size() - 1; j++) {
                curr.add(last.get(j) + last.get(j + 1));
            }
            curr.add(1);
            res.add(curr);
        }
        return res;
    }
}
// @lc code=end
