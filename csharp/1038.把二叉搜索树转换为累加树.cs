/*
 * @lc app=leetcode.cn id=1038 lang=csharp
 *
 * [1038] 把二叉搜索树转换为累加树
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
    public TreeNode BstToGst(TreeNode root)
    {
        Traverse(root);
        return root;
    }

    int lastVisit = 0;
    void Traverse(TreeNode root)
    {
        if (root == null)
            return;
        Traverse(root.right);
        root.val += lastVisit;
        lastVisit = root.val;
        Traverse(root.left);
    }
}
// @lc code=end

