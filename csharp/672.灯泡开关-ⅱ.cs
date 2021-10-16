/*
 * @lc app=leetcode.cn id=672 lang=csharp
 *
 * [672] 灯泡开关 Ⅱ
 */

// @lc code=start
public class Solution {
    public int FlipLights(int n, int presses) {
        n = Math.Min(n, 3);
        if (presses == 0) return 1;
        if (presses == 1) return n == 1 ? 2 : n == 2 ? 3 : 4;
        if (presses == 2) return n == 1 ? 2 : n == 2 ? 4 : 7;
        return n == 1 ? 2 : n == 2 ? 4 : 8;
    }
}
// @lc code=end

