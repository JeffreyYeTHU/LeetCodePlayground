using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=236 lang=csharp
 *
 * [236] 二叉树的最近公共祖先
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
        // Contain(root, p, q);
        // return lca;

        // solution 2: save parent
        Traverse(root);
        var set = new HashSet<TreeNode>();
        while(p != root){
            set.Add(p);
            p = parents[p];
        }
        while(q != root){
            if(set.Contains(q))
                return q;
            q = parents[q];
        }
        return root;
    }

    // TreeNode lca;
    // bool Contain(TreeNode root, TreeNode p, TreeNode q){
    //     if(root == null)
    //         return false;
    //     bool left = Contain(root.left, p, q);
    //     bool right = Contain(root.right, p, q);
    //     if((left && right) || ((root.val == p.val || root.val == q.val) && (left || right)))
    //         lca = root;
    //     bool res = (root.val == p.val || root.val == q.val) || left || right;
    //     return res;
    // }

    Dictionary<TreeNode, TreeNode> parents = new();
    void Traverse(TreeNode root){
        if(root == null)
            return;
        if (root.left != null)
            parents.Add(root.left, root);
        if (root.right != null)
            parents.Add(root.right, root);
        Traverse(root.left);
        Traverse(root.right);
    }
}
// @lc code=end

