package leetcode;

public class Bst {

    int sum = 0;

    public TreeNode convertBST(TreeNode root) {
        if (root == null)
            return root;

        convertBST(root.right);
        sum += root.val;
        root.val = sum;
        convertBST(root.left);

        return root;
    }

    public TreeNode deleteNode(TreeNode root, int key) {
        if (root == null)
            return null;

        if (root.val == key) { // found
            // case a: both are null
            if (root.left == null && root.right == null)
                return null;

            // case b: left or right is null
            if (root.left == null)
                return root.right;
            if (root.right == null)
                return root.left;

            // case c: both not null
            TreeNode max = getMax(root.left);
            root.val = max.val;
            root.left = deleteNode(root.left, max.val);
        } else if (root.val < key) {
            root.right = deleteNode(root.right, key);
        } else {
            root.left = deleteNode(root.left, key);
        }

        return root;
    }

    private TreeNode getMax(TreeNode root) {
        if (root == null)
            return null;
        TreeNode max = root;
        while (max.right != null) {
            max = max.right;
        }
        return max;
    }

    public TreeNode insertIntoBST(TreeNode root, int val) {
        if (root == null)
            return new TreeNode(val);

        if (root.val < val) {
            root.right = insertIntoBST(root.right, val);
        } else {
            root.left = insertIntoBST(root.left, val);
        }

        return root;
    }

    public boolean isValidBST(TreeNode root) {
        return isValidBST(root, null, null);
    }

    public boolean isValidBST(TreeNode root, TreeNode min, TreeNode max) {
        if (root == null)
            return true;

        if (min != null && root.val <= min.val) {
            return false;
        }
        if (max != null && root.val >= max.val) {
            return false;
        }

        return isValidBST(root.left, min, root) && isValidBST(root.right, root, max);
    }
}
