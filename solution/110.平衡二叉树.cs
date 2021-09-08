/*
 * @lc app=leetcode.cn id=110 lang=csharp
 *
 * [110] 平衡二叉树
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
    public bool IsBalanced(TreeNode root)
    {
        return Height(root) != -1;
    }

    // if balance, return height, otherwise -1
    int Height(TreeNode root)
    {
        if (root == null)
            return 0;

        int left = Height(root.left);
        int right = Height(root.right);
        if (left == -1 || right == -1 || Math.Abs(left - right) > 1)
            return -1;
        else
            return Math.Max(left, right) + 1;
    }
}
// @lc code=end

