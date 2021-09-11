/*
 * @lc app=leetcode.cn id=108 lang=csharp
 *
 * [108] 将有序数组转换为二叉搜索树
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
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return Build(nums, 0, nums.Length - 1);
    }

    // build tree out of nums[left...right];
    TreeNode Build(int[] nums, int left, int right)
    {
        if (left > right)
            return null;

        int mid = left + (right - left) / 2;
        var root = new TreeNode(nums[mid]);
        root.left = Build(nums, left, mid - 1);
        root.right = Build(nums, mid + 1, right);
        return root;
    }
}
// @lc code=end

