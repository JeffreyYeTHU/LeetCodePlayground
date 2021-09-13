/*
 * @lc app=leetcode.cn id=84 lang=csharp
 *
 * [84] 柱状图中最大的矩形
 */

// @lc code=start
public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        int n = heights.Length;
        int[] left = new int[n];
        int[] right = new int[n];
        var stk = new Stack<int>();
        for (int i = 0; i < n; i++)
        {
            while (stk.Count != 0 && heights[stk.Peek()] >= heights[i])
                stk.Pop();
            left[i] = stk.Count == 0 ? -1 : stk.Peek();
            stk.Push(i);
        }
        stk.Clear();
        for (int i = n - 1; i >= 0; i--)
        {
            while (stk.Count != 0 && heights[stk.Peek()] >= heights[i])
                stk.Pop();
            right[i] = stk.Count == 0 ? n : stk.Peek();
            stk.Push(i);
        }

        int res = 0;
        for (int i = 0; i < n; i++)
        {
            res = Math.Max(res, (right[i] - left[i] - 1) * heights[i]);
        }
        return res;
    }
}
// @lc code=end

