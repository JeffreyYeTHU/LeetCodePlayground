/*
 * @lc app=leetcode.cn id=173 lang=csharp
 *
 * [173] 二叉搜索树迭代器
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
public class BSTIterator {

    int idx;
    public BSTIterator(TreeNode root) {
        InOrder(root);
        idx = 0;
    }
    
    public int Next() {
        return data[idx++];
    }
    
    public bool HasNext() {
        return idx < data.Count;
    }

    List<int> data = new();
    void InOrder(TreeNode root){
        if(root == null)
            return;
        InOrder(root.left);
        data.Add(root.val);
        InOrder(root.right);
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */
// @lc code=end

