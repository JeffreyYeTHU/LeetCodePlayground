package com.jeffrey.binary_tree;

import java.util.*;

public final class MaxBinaryTree{
    public TreeNode constructMaximumBinaryTree(int[] nums) {
        if (nums.length == 1)
            return new TreeNode(nums[0]);

        // find max index
        int maxIdx = 0;
        for (int i = 0; i < nums.length; i++) {
            if (nums[i] > nums[maxIdx])
                maxIdx = i;
        }

        TreeNode root = new TreeNode(nums[maxIdx]);
        if (maxIdx >= 1)
            root.left = constructMaximumBinaryTree(Arrays.copyOfRange(nums, 0, maxIdx));
        if (maxIdx < nums.length - 1)
            root.right = constructMaximumBinaryTree(Arrays.copyOfRange(nums, maxIdx + 1, nums.length));
        return  root;
    }

    public TreeNode buildTreeFromPreAndIn(int[] preorder, int[] inorder) {
        return build(preorder, 0, preorder.length - 1,
                inorder, 0, inorder.length - 1);
    }

    private  TreeNode build(int[] preorder, int preStart, int preEnd,
                            int[] inorder, int inStart, int inEnd){
        // base case
        if (preStart > preEnd)
            return  null;

        // build root
        int rootVal = preorder[preStart];
        int idx = -1;
        for (int i = inStart; i <= inEnd; i++) {
            if (inorder[i] == rootVal){
                idx = i;
                break;
            }
        }
        TreeNode root = new TreeNode(rootVal);

        // build left and right
        root.left = build(preorder, preStart + 1, preStart + idx - inStart,
                          inorder, inStart, idx - 1);
        root.right = build(preorder, preStart + idx - inStart + 1, preEnd,
                           inorder, idx + 1, inEnd);
        return root;
    }

    public TreeNode buildTreeFromInAndPost(int[] inorder, int[] postorder){
        return buildHelper(inorder, 0, inorder.length - 1,
                           postorder, 0, postorder.length - 1);
    }

    private TreeNode buildHelper(int[] inorder, int inStart, int inEnd,
                                 int[] postorder, int postStart, int postEnd){
        // base case
        if (inStart > inEnd)
            return  null;

        // build root
        int rootVal = postorder[postEnd];
        int index = -1;
        for (int i = inStart; i <= inEnd; i++) {
            if (inorder[i] == rootVal){
                index = i;
            }
        }
        TreeNode root = new TreeNode(rootVal);

        // build children
        root.left = buildHelper(inorder, inStart, index - 1,
                                postorder, postStart, postStart + index - inStart - 1);
        root.right = buildHelper(inorder, index + 1, inEnd,
                        postorder, postStart + index - inStart, postEnd - 1);
        return root;
    }

    Map<String, Integer> freqs = new HashMap<>();
    List<TreeNode> res = new ArrayList<>();
    public List<TreeNode> findDuplicateSubtrees(TreeNode root) {
        traverse(root);
        return res;
    }

    private String traverse(TreeNode root){
        // base case
        if (root == null)
            return "#";

        String left = traverse(root.left);
        String right = traverse(root.right);
        String curr = left + "," + right + "," + root.val;
        if (!freqs.containsKey(curr)){
            freqs.put(curr, 1);
        } else {
            Integer freq = freqs.get(curr);
            if (freq == 1)
                res.add(root);
            freqs.put(curr, freq + 1);
        }

        return curr;
    }
}