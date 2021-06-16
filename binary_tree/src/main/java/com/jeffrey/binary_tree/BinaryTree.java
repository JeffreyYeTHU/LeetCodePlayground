package com.jeffrey.binary_tree;

import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

public final class BinaryTree {
    public static List<Integer> inorderRecur(TreeNode root) {
        List<Integer> traversalResult = new ArrayList<>();
        inorderRecurHelper(root, traversalResult);
        return traversalResult;
    }

    public static List<Integer> preorderIter(TreeNode root) {
        List<Integer> res = new ArrayList<>();
        Stack<TreeNode> nodes = new Stack<>();
        TreeNode currNode = root;
        while (!nodes.empty() || currNode != null) {
            if (currNode != null) {
                res.add(currNode.getVal());
                nodes.add(currNode);
                currNode = currNode.getLeft();
            } else {
                var node = nodes.pop();
                currNode = node.getRight();
            }
        }
        return res;
    }

    public static List<Integer> inorderIter(TreeNode root) {
        List<Integer> res = new ArrayList<>();
        Stack<TreeNode> nodes = new Stack<>();
        TreeNode currNode = root;
        while (!nodes.empty() || currNode != null) {
            if (currNode != null) {
                nodes.add(currNode);
                currNode = currNode.getLeft();
            } else {
                var node = nodes.pop();
                res.add(node.getVal());
                currNode = node.getRight();
            }
        }
        return res;
    }

    public static List<Integer> postorderIter(TreeNode root) {
        List<Integer> res = new ArrayList<>();
        Stack<TreeNode> nodes = new Stack<>();
        nodes.add(root);
        TreeNode curr = root;
        TreeNode pre = null;
        while (!nodes.empty()) {
            curr = nodes.peek();
            if ((curr.getLeft() == null && curr.getRight() == null)
                    || pre != null && (pre.getLeft() == curr || pre.getRight() == curr)) {
                res.add(curr.getVal());
                nodes.pop();
                pre = curr;
            } else {
                if (curr.getLeft() != null)
                    nodes.push(curr.getLeft());
                if (curr.getRight() != null)
                    nodes.push(curr.getRight());
            }
        }
        return res;
    }

    private static void inorderRecurHelper(TreeNode root, List<Integer> result) {
        if (root != null) {
            inorderRecurHelper(root.getLeft(), result);
            result.add(root.getVal());
            inorderRecurHelper(root.getRight(), result);
        }
    }
}