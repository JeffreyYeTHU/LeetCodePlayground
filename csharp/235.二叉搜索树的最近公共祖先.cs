/*
 * @lc app=leetcode.cn id=235 lang=csharp
 *
 * [235] 二叉搜索树的最近公共祖先
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        // solution 1: recursive
        // if(p.val < root.val && q.val < root.val)
        //     return LowestCommonAncestor(root.left, p, q);
        // else if (p.val > root.val && q.val > root.val)
        //     return LowestCommonAncestor(root.right, p, q);
        // else
        //     return root;

        // solution 2: iterative
        var ancestor = root;
        while(true){
            if(p.val < ancestor.val && q.val < ancestor.val)
                ancestor = ancestor.left;
            else if (p.val > ancestor.val && q.val > ancestor.val)
                ancestor = ancestor.right;
            else
                break;
        }
        return ancestor;
    }
}
// @lc code=end

