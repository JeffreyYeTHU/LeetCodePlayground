/*
 * @lc app=leetcode.cn id=99 lang=csharp
 *
 * [99] 恢复二叉搜索树
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
    public void RecoverTree(TreeNode root)
    {
        Traverse(root);
        var nodeToSwap = FindNodeToSwap(inorderNodes);
        Swap(nodeToSwap.Item1, nodeToSwap.Item2);
    }

    List<TreeNode> inorderNodes = new List<TreeNode>();
    void Traverse(TreeNode root)
    {
        if (root == null)
            return;
        Traverse(root.left);
        inorderNodes.Add(root);
        Traverse(root.right);
    }

    (TreeNode, TreeNode) FindNodeToSwap(List<TreeNode> inorder)
    {
        var idx = new List<int>();
        for (int i = 0, j = 1; j < inorder.Count; i++, j++)
        {
            if (inorder[i].val > inorder[j].val)
                idx.Add(i);
        }
        if (idx.Count == 1)
        {
            int i = idx[0];
            int j = i + 1;
            return (inorder[i], inorder[j]);
        }
        else
        {
            int i = idx[0];
            int j = idx[1] + 1;
            return (inorder[i], inorder[j]);
        }
    }

    void Swap(TreeNode x, TreeNode y)
    {
        int tmp = x.val;
        x.val = y.val;
        y.val = tmp;
    }
}
// @lc code=end

