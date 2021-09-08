/*
 * @lc app=leetcode.cn id=113 lang=csharp
 *
 * [113] 路径总和 II
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
    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        if (root == null)
            return paths;
        Backtrack(root, new List<int>() { root.val }, root.val, targetSum);
        return paths;
    }

    List<IList<int>> paths = new List<IList<int>>();
    void Backtrack(TreeNode root, List<int> path, int sum, int target)
    {
        if (root == null)
            return;
        else if (root.left == null && root.right == null)
        {
            if (sum == target)
            {
                paths.Add(new List<int>(path));
                return;
            }
        }

        if (root.left != null)
        {
            path.Add(root.left.val);
            sum += root.left.val;
            Backtrack(root.left, path, sum, target);
            sum -= root.left.val;
            path.RemoveAt(path.Count - 1);
        }

        if (root.right != null)
        {
            path.Add(root.right.val);
            sum += root.right.val;
            Backtrack(root.right, path, sum, target);
            sum -= root.right.val;
            path.RemoveAt(path.Count - 1);
        }
    }
}
// @lc code=end

