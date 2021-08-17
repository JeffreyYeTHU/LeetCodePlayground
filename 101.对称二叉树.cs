/*
 * @lc app=leetcode.cn id=101 lang=csharp
 *
 * [101] 对称二叉树
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
public class Solution {
    public bool IsSymmetric(TreeNode root) {
        return Check(root, root);
    }

    bool Check(TreeNode p, TreeNode q){
        if (p == null && q == null)
            return true;
        else if (p == null || q == null)
            return false;

        return p.val == q.val
            && Check(p.left, q.right)
            && Check(p.right, q.left);
    }
}
// @lc code=end

