/*
 * @lc app=leetcode.cn id=513 lang=csharp
 *
 * [513] 找树左下角的值
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
    public int FindBottomLeftValue(TreeNode root) {
        var queue = new Queue<TreeNode>();
        int res = root.val;
        queue.Enqueue(root);
        while(queue.Count != 0){
            int cnt = queue.Count;
            for(int i=0; i< cnt; i++){
                var curr = queue.Dequeue();
                if(i == 0)
                    res = curr.val;
                if(curr.left != null)
                    queue.Enqueue(curr.left);
                if (curr.right != null)
                    queue.Enqueue(curr.right);
            }
        }
        return res;
    }
}
// @lc code=end

