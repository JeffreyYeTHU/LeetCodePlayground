/*
 * @lc app=leetcode.cn id=105 lang=csharp
 *
 * [105] 从前序与中序遍历序列构造二叉树
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
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        return BuildTree(preorder, inorder, 0, 0, preorder.Length);
    }

    TreeNode BuildTree(int[] preorder, int[] inorder, int preStart, int inStart, int len)
    {
        if (len <= 0)
            return null;

        var root = new TreeNode(preorder[preStart]);
        int idx = Array.IndexOf(inorder, preorder[preStart]);
        int leftLen = idx - inStart;
        int rightLen = len - leftLen - 1;
        root.left = BuildTree(preorder, inorder, preStart + 1, inStart, leftLen);
        root.right = BuildTree(preorder, inorder, preStart + leftLen + 1, idx + 1, rightLen);
        return root;
    }
}
// @lc code=end

