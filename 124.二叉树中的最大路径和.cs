/*
 * @lc app=leetcode.cn id=124 lang=csharp
 *
 * [124] 二叉树中的最大路径和
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
    public int MaxPathSum(TreeNode root)
    {
        var max = GetMax(root);
        return max[0];
    }

    // res[0] - max path sum of the tree
    // res[1] - math path sum with node root
    // res[2] - math path sum with node root, and only its left sub-tree
    // res[3] - math path sum with node root, and only its right sub-tree
    int[] GetMax(TreeNode root)
    {
        if (root == null)
            return new int[] { int.MinValue, int.MinValue, int.MinValue, int.MinValue };

        int[] left = GetMax(root.left);
        int[] right = GetMax(root.right);
        int leftMax = Math.Max(left[2], left[3]);
        int rightMax = Math.Max(right[2], right[3]);
        int[] res = new int[4];

        res[1] = root.val;
        res[2] = root.val;
        res[3] = root.val;
        if (leftMax > 0)
        {
            res[1] += leftMax;
            res[2] += leftMax;
        }
        if (rightMax > 0)
        {
            res[1] += rightMax;
            res[3] += rightMax;
        }

        res[0] = Math.Max(res[1], Math.Max(left[0], right[0]));
        return res;
    }
}
// @lc code=end

