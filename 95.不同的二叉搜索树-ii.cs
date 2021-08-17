/*
 * @lc app=leetcode.cn id=95 lang=csharp
 *
 * [95] 不同的二叉搜索树 II
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public IList<TreeNode> GenerateTrees(int n)
    {
        return GenTrees(1, n);
    }

    List<TreeNode> GenTrees(int start, int end)
    {
        if (start > end)
            return new List<TreeNode>() { null };
        var res = new List<TreeNode>();
        for (int i = start; i <= end; i++)
        {
            var leftTrees = GenTrees(start, i - 1);
            var rightTrees = GenTrees(i + 1, end);
            foreach (var left in leftTrees)
            {
                foreach (var right in rightTrees)
                {
                    var root = new TreeNode(i);
                    root.left = left;
                    root.right = right;
                    res.Add(root);
                }
            }
        }
        return res;
    }
}
// @lc code=end

