/*
 * @lc app=leetcode.cn id=106 lang=csharp
 *
 * [106] 从中序与后序遍历序列构造二叉树
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
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        return Build(inorder, postorder, 0, 0, inorder.Length);
    }

    TreeNode Build(int[] inorder, int[] postorder, int instart, int poststart, int len)
    {
        if (len <= 0)
            return null;

        int rootVal = postorder[poststart + len - 1];
        var root = new TreeNode(rootVal);
        int idx = Array.IndexOf(inorder, rootVal);
        int leftLen = idx - instart;
        int rightLen = len - leftLen - 1;
        root.left = Build(inorder, postorder, instart, poststart, leftLen);
        root.right = Build(inorder, postorder, idx + 1, poststart + leftLen, rightLen);
        return root;
    }
}
// @lc code=end

