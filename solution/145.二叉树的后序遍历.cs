/*
 * @lc app=leetcode.cn id=145 lang=csharp
 *
 * [145] 二叉树的后序遍历
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
    Stack<TreeNode> stk = new Stack<TreeNode>();
    List<int> postorder = new List<int>();
    TreeNode lastVisit = new TreeNode(-1);
    public IList<int> PostorderTraversal(TreeNode root)
    {
        // solution 1:
        // Traverse(root);
        // return postorder;

        // solution 2:
        // var res = new List<int>();
        // var s = new Stack<TreeNode>();
        // TreeNode curr = root;
        // TreeNode lastVisit = root;
        // while(curr != null || s.Count !=0){
        //     while(curr != null){
        //         s.Push(curr);
        //         curr = curr.left;
        //     }

        //     curr = s.Peek();
        //     if(curr.right == null || lastVisit == curr.right){
        //         res.Add(curr.val);
        //         s.Pop();
        //         lastVisit = curr;
        //         curr = null;
        //     } else {
        //         curr = curr.right;
        //     }
        // }
        // return res;

        // solution 3:
        if (root == null)
            return postorder;

        PushLeftBranch(root);
        while (stk.Count != 0)
        {
            var p = stk.Peek();
            if ((p.left == null || p.left == lastVisit) && p.right != lastVisit)
                PushLeftBranch(p.right);
            if (p.right == null || p.right == lastVisit)
            {
                postorder.Add(p.val);
                lastVisit = p;
                stk.Pop();
            }
        }
        return postorder;
    }

    void PushLeftBranch(TreeNode p)
    {
        while (p != null)
        {
            stk.Push(p);
            p = p.left;
        }
    }

    // List<int> postorder = new List<int>();
    // void Traverse(TreeNode root){
    //     if (root == null)
    //         return;
    //     Traverse(root.left);
    //     Traverse(root.right);
    //     postorder.Add(root.val);
    // }
}
// @lc code=end

