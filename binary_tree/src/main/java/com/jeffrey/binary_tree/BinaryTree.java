package com.jeffrey.binary_tree;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;
import java.util.Stack;

public final class BinaryTree {
    public static List<Integer> inOrderRecur(TreeNode root) {
        List<Integer> traversalResult = new ArrayList<>();
        inOrderRecurHelper(root, traversalResult);
        return traversalResult;
    }

    public static List<Integer> inOrderIter(TreeNode root) {
        List<Integer> res = new ArrayList<>();
        Stack<TreeNode> nodes = new Stack<>();
        TreeNode currNode = root;
        while (!nodes.empty() || currNode != null) {
            if (currNode != null) {
                nodes.push(currNode);
                currNode = currNode.getLeft();
            } else {
                var node = nodes.pop();
                res.add(node.getVal());
                currNode = node.getRight();
            }
        }
        return res;
    }

    public static List<Integer> preOrderIter(TreeNode root) {
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

    public static List<Integer> postOrderIter(TreeNode root) {
        List<Integer> res = new ArrayList<>();
        Stack<TreeNode> nodes = new Stack<>();
        if (root == null)
            return res;
        nodes.add(root);
        TreeNode curr = root;
        TreeNode preVisit = null;
        while (!nodes.empty()) {
            curr = nodes.peek();
            if (curr.hasNoChildren() || preVisit != null && preVisit == curr.getRight()) {
                res.add(curr.getVal());
                nodes.pop();
                preVisit = curr;
            } else {
                if (curr.getRight() != null)
                    nodes.push(curr.getRight());
                if (curr.getLeft() != null)
                    nodes.push(curr.getLeft());
            }
        }
        return res;
    }

    public static List<Integer> bfs(TreeNode root) {
        Queue<TreeNode> nodes = new LinkedList<>();
        List<Integer> res = new ArrayList<>();
        if (root == null)
            return res;
        nodes.add(root);
        while (!nodes.isEmpty()) {
            var curr = nodes.remove();
            res.add(curr.getVal());
            if (curr.getLeft() != null)
                nodes.add(curr.getLeft());
            if (curr.getRight() != null)
                nodes.add(curr.getRight());
        }
        return res;
    }

    private static void inOrderRecurHelper(TreeNode root, List<Integer> result) {
        if (root != null) {
            inOrderRecurHelper(root.getLeft(), result);
            result.add(root.getVal());
            inOrderRecurHelper(root.getRight(), result);
        }
    }
}