/*
 * @lc app=leetcode.cn id=144 lang=csharp
 *
 * [144] 二叉树的前序遍历
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
    public IList<int> PreorderTraversal(TreeNode root) {
        // // solution 1: recursive
        // Traverse(root);
        // return preorder;

        // solution 2: iterative
        var s = new Stack<TreeNode>();
        var res = new List<int>();
        TreeNode p = root;
        while(p != null || s.Count != 0){
            if(p != null){
                res.Add(p.val);
                s.Push(p);
                p = p.left;
            }
            else{
                p = s.Pop().right;
            }
        }
        return res;
    }

    // List<int> preorder = new List<int>();
    // void Traverse(TreeNode root){
    //     if (root == null)
    //         return;
        
    //     preorder.Add(root.val);
    //     Traverse(root.left);
    //     Traverse(root.right);
    // }
}
// @lc code=end

