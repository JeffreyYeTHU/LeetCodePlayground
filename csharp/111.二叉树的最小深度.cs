/*
 * @lc app=leetcode.cn id=111 lang=csharp
 *
 * [111] 二叉树的最小深度
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
    public int MinDepth(TreeNode root)
    {
        // solution 1:
        // if (root == null)
        //     return 0;
        // int left = MinDepth(root.left);
        // int right = MinDepth(root.right);
        // if (left == 0)
        //     return right + 1;
        // else if (right == 0)
        //     return left + 1;
        // else
        //     return Math.Min(left, right) + 1;

        // solution 2:
        if (root == null)
            return 0;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        int depth = 0;
        while (q.Count != 0)
        {
            depth++;
            int roundCnt = q.Count;
            while (roundCnt > 0)
            {
                var node = q.Dequeue();
                if (node.left == null && node.right == null)
                    return depth;
                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
                roundCnt--;
            }
        }
        return depth;
    }
}
// @lc code=end

