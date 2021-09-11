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
public class Solution
{
    Stack<TreeNode> s = new Stack<TreeNode>();
    List<int> preorder = new List<int>();
    TreeNode lastVisit = new TreeNode(-1);
    public IList<int> PreorderTraversal(TreeNode root)
    {
        if (root == null)
            return preorder;

        PushLeftBranch(root);
        while (s.Count != 0)
        {
            var p = s.Peek();
            if ((p.left == null || p.left == lastVisit) && p.right != lastVisit)
            {
                PushLeftBranch(p.right);
            }

            if (p.right == null || p.right == lastVisit)
            {
                lastVisit = p;
                s.Pop();
            }
        }
        return preorder;
    }

    void PushLeftBranch(TreeNode p)
    {
        while (p != null)
        {
            preorder.Add(p.val);
            s.Push(p);
            p = p.left;
        }
    }
}
// @lc code=end

