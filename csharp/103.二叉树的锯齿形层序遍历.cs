/*
 * @lc app=leetcode.cn id=103 lang=csharp
 *
 * [103] 二叉树的锯齿形层序遍历
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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        var res = new List<IList<int>>();
        if (root == null)
            return res;
        bool leftToRight = true;
        var q = new List<TreeNode>();
        q.Add(root);
        while(q.Count != 0){
            var curr = new List<int>();
            int roundCnt = q.Count;
            if(leftToRight)
            {
                while(roundCnt > 0){
                    curr.Add(q[0].val);
                    if(q[0].left != null)
                        q.Add(q[0].left);
                    if(q[0].right != null)
                        q.Add(q[0].right);
                    q.RemoveAt(0);
                    roundCnt--;
                }
                leftToRight = !leftToRight;
            }
            else
            {
                while(roundCnt > 0){
                    var last = q.Last();
                    curr.Add(last.val);
                    if(last.right != null)
                        q.Insert(0, last.right);
                    if(last.left != null)
                        q.Insert(0, last.left);
                    q.RemoveAt(q.Count - 1);
                    roundCnt--;
                }
                leftToRight = !leftToRight;
            }
            res.Add(curr);
        }
        return res;
    }
}
// @lc code=end

