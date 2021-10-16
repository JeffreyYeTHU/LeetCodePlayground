/*
 * @lc app=leetcode.cn id=654 lang=csharp
 *
 * [654] 最大二叉树
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
    public TreeNode ConstructMaximumBinaryTree(int[] nums) {
        return BuildTree(nums, 0, nums.Length -1);
    }

    TreeNode BuildTree(int[] nums, int start, int end){
        if(start > end)
            return null;

        int maxIdx = start;
        for(int i = start+1; i<=end; i++){
            if(nums[i] > nums[maxIdx])
                maxIdx = i;
        }
        var root = new TreeNode(nums[maxIdx]);
        root.left = BuildTree(nums, start, maxIdx -1);
        root.right = BuildTree(nums, maxIdx+1, end);
        return root;
    }
}
// @lc code=end

