/*
 * @lc app=leetcode.cn id=404 lang=csharp
 *
 * [404] 左叶子之和
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
    public int SumOfLeftLeaves(TreeNode root) {
        Traverse(root.left, root);
        Traverse(root.right, root);
        return sum;
    }

    int sum = 0;
    void Traverse(TreeNode curr, TreeNode parent){
        if (curr == null)
            return;
        if(curr.left == null && curr.right == null){
            if(parent.left == curr)
                sum += curr.val;
            else
                return;
        }

        Traverse(curr.left, curr);
        Traverse(curr.right, curr);
    }
}
// @lc code=end

