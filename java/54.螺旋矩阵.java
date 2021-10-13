import java.io.Console;
import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

/*
 * @lc app=leetcode.cn id=54 lang=java
 *
 * [54] 螺旋矩阵
 */

// @lc code=start
class Solution {
    public List<Integer> spiralOrder(int[][] matrix) {
        List<Integer> res = new ArrayList<Integer>();
        int m = matrix.length;
        int n = matrix[0].length;
        int large = Math.max(m, n);
        int row = 0;
        int col = 0;
        for (int cnt = 0; cnt < (large + 1) / 2; cnt++) {
            // System.out.println("cnt=" + cnt + ",m=" + m + ",n=" + n);
            // right
            for (; col < n; col++) {
                if (matrix[row][col] == Integer.MAX_VALUE)
                    break;
                res.add(matrix[row][col]);
                matrix[row][col] = Integer.MAX_VALUE;
            }
            col--;
            row++;
            // down
            for (; row < m; row++) {
                if (matrix[row][col] == Integer.MAX_VALUE)
                    break;
                res.add(matrix[row][col]);
                matrix[row][col] = Integer.MAX_VALUE;
            }
            row--;
            col--;
            // left
            for (; col >= 0; col--) {
                // System.out.println("row=" + row + ",col=" + col);
                if (matrix[row][col] == Integer.MAX_VALUE)
                    break;
                res.add(matrix[row][col]);
                matrix[row][col] = Integer.MAX_VALUE;
            }
            col++;
            row--;
            // up
            for (; row >= 0; row--) {
                if (matrix[row][col] == Integer.MAX_VALUE)
                    break;
                res.add(matrix[row][col]);
                matrix[row][col] = Integer.MAX_VALUE;
            }
            row++;
            col++;
        }
        return res;
    }
}
// @lc code=end
