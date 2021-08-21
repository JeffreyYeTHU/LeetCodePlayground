/*
 * @lc app=leetcode.cn id=199 lang=csharp
 *
 * [199] 二叉树的右视图
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
    public IList<int> RightSideView(TreeNode root) {
        var res = new List<int>();
        if (root == null) return res;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while(q.Count != 0){
            int cnt = q.Count;
            for(int i = 0; i<cnt; i++){
                var node = q.Dequeue();
                if(i == 0)
                    res.Add(node.val);
                if (node.right != null)
                    q.Enqueue(node.right);
                if (node.left != null)
                    q.Enqueue(node.left);
            }
        }
        return res;
    }
}
// @lc code=end

