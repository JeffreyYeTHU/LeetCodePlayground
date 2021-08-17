/*
 * @lc app=leetcode.cn id=96 lang=csharp
 *
 * [96] 不同的二叉搜索树
 */

// @lc code=start
public class Solution
{
    public int NumTrees(int n)
    {
        return CountTrees(1, n);
    }

    Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
    int CountTrees(int start, int end)
    {
        int res = 0;
        if (start > end)
            return res;

        if (memo.ContainsKey((start, end)))
            return memo[(start, end)];
        for (int i = start; i <= end; i++)
        {
            int leftCnt = CountTrees(start, i - 1);
            int rightCnt = CountTrees(i + 1, end);
            if (leftCnt == 0 && rightCnt == 0)
                res += 1;
            else if (leftCnt == 0)
                res += rightCnt;
            else if (rightCnt == 0)
                res += leftCnt;
            else
                res += leftCnt * rightCnt;
        }
        memo.Add((start, end), res);
        return res;
    }
}
// @lc code=end

