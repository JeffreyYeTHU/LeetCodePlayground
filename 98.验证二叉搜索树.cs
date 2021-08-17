/*
 * @lc app=leetcode.cn id=98 lang=csharp
 *
 * [98] 验证二叉搜索树
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
    public bool IsValidBST(TreeNode root)
    {
        if (root == null)
            return true;

        bool leftValid = IsValidBST(root.left);
        bool rightValid = IsValidBST(root.right);

        var leftMax = root.left;
        while (leftMax != null && leftMax.right != null)
            leftMax = leftMax.right;

        var rightMin = root.right;
        while (rightMin != null && rightMin.left != null)
            rightMin = rightMin.left;

        bool rootValid;
        if (leftMax == null && rightMin == null)
            rootValid = true;
        else if (leftMax == null)
            rootValid = rightMin.val > root.val;
        else if (rightMin == null)
            rootValid = leftMax.val < root.val;
        else
            rootValid = leftMax.val < root.val && root.val < rightMin.val;

        return leftValid && rightValid && rootValid;
    }
}
// @lc code=end

