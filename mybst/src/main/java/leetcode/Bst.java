package leetcode;

import java.util.ArrayList;
import java.util.List;

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

    int[][] memo;

    public int numTrees(int n) {
        memo = new int[n + 1][n + 1];
        return count(1, n);
    }

    private int count(int low, int high) {
        if (low > high)
            return 1;

        // search memo
        if (memo[low][high] != 0)
            return memo[low][high];

        int res = 0;
        for (int i = low; i <= high; i++) {
            int left = count(low, i - 1);
            int right = count(i + 1, high);
            res += left * right;
        }

        // update memo
        memo[low][high] = res;
        return res;
    }

    public List<TreeNode> generateTrees(int n) {
        if (n == 0)
            return new ArrayList<>();
        return genBst(1, n);
    }

    private List<TreeNode> genBst(int low, int high) {
        List<TreeNode> res = new ArrayList<>();
        if (low > high) {
            res.add(null);
            return res;
        }

        for (int mid = low; mid <= high; mid++) {
            List<TreeNode> leftTree = genBst(low, mid - 1);
            List<TreeNode> rightTree = genBst(mid + 1, high);
            for (TreeNode left : leftTree) {
                for (TreeNode right : rightTree) {
                    TreeNode root = new TreeNode(mid);
                    root.left = left;
                    root.right = right;
                    res.add(root);
                }
            }
        }

        return res;
    }

    public int maxSumBST(TreeNode root) {
        traverse(root);
        return maxSum;
    }

    int maxSum = 0;

    // return int[]{isBst, min, max, sum}
    int[] traverse(TreeNode root) {
        if (root == null)
            return new int[] { 1, Integer.MAX_VALUE, Integer.MIN_VALUE, 0 };

        int[] left = traverse(root.left);
        int[] right = traverse(root.right);

        int[] res = new int[4];
        if (left[0] == 1 && right[0] == 1 && root.val > left[2] && root.val < right[1]) {
            res[0] = 1;
            res[1] = Math.min(root.val, left[1]);
            res[2] = Math.max(root.val, right[2]);
            res[3] = left[3] + right[3] + root.val;
            maxSum = Math.max(maxSum, res[3]);
        } else {
            res[0] = 0;
        }

        return res;
    }
}
