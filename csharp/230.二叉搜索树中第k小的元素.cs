/*
 * @lc app=leetcode.cn id=230 lang=csharp
 *
 * [230] 二叉搜索树中第K小的元素
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
    public int KthSmallest(TreeNode root, int k) {
        InOrderTraversal(root);
        return inorder[k-1].val;
    }

    List<TreeNode> inorder = new List<TreeNode>();
    void InOrderTraversal(TreeNode root){
        if(root == null)return;
        InOrderTraversal(root.left);
        inorder.Add(root);
        InOrderTraversal(root.right);
    }
}
// @lc code=end

