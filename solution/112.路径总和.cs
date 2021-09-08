/*
 * @lc app=leetcode.cn id=112 lang=csharp
 *
 * [112] 路径总和
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
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        if (root == null)
            return false;
        if (root.left == null && root.right == null && targetSum == root.val)
            return true;

        bool leftHas = HasPathSum(root.left, targetSum - root.val);
        bool rightHas = HasPathSum(root.right, targetSum - root.val);
        return leftHas || rightHas;
    }
}
// @lc code=end

