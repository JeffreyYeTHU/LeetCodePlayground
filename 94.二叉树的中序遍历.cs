/*
 * @lc app=leetcode.cn id=94 lang=csharp
 *
 * [94] 二叉树的中序遍历
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
    public IList<int> InorderTraversal(TreeNode root)
    {
        // solution 1:
        // Traverse(root);
        // return res;

        // solution 2:
        var s = new Stack<TreeNode>();
        var res = new List<int>();
        TreeNode p = root;
        while (p != null || s.Count != 0){
            if(p != null){
                s.Push(p);
                p = p.left;
            } else {
                var node = s.Pop();
                res.Add(node.val);
                p = node.right;
            }
        }
        return res;
    }

    // List<int> res = new List<int>();
    // void Traverse(TreeNode root)
    // {
    //     if (root == null)
    //         return;
    //     Traverse(root.left);
    //     res.Add(root.val);
    //     Traverse(root.right);
    // }
}
// @lc code=end

