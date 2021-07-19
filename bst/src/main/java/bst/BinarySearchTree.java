package bst;

import java.util.ArrayList;
import java.util.List;

public class BinarySearchTree {
    public int kthSmallest(TreeNode root, int k) {
        traverse(root, k);
        return res;
    }

    List<Integer> orderedList = new ArrayList<>();
    private void traverse(TreeNode root){
        // base case
        if (root == null)
            return;

        // inorder
        traverse(root.left);
        orderedList.add(root.val);
        traverse(root.right);
    }

    int res;  // store result
    int rank = 0;  // store rank
    private void traverse(TreeNode root, int k){
        if (root == null)
            return;

        traverse(root.left, k);
        rank++;
        if (rank == k){
            res = root.val;
            return;
        }
        traverse(root.right, k);
    }
}
