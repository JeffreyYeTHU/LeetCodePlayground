/*
 * @lc app=leetcode.cn id=114 lang=csharp
 *
 * [114] 二叉树展开为链表
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
    public void Flatten(TreeNode root)
    {
        FlattenHelper(root);
    }

    TreeNode FlattenHelper(TreeNode root)
    {
        if (root == null)
            return null;

        var left = FlattenHelper(root.left);
        var right = FlattenHelper(root.right);

        root.left = null;
        root.right = left;
        var leftend = root;
        while (leftend.right != null)
            leftend = leftend.right;
        leftend.right = right;

        return root;
    }
}
// @lc code=end

