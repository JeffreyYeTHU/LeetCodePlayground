package com.jeffrey.binary_tree;

import static org.junit.jupiter.api.Assertions.assertIterableEquals;

import java.util.ArrayList;
import java.util.List;

import org.junit.jupiter.api.Test;

class BinaryTreeTests {

	@Test
	void inorderTraversal_normalCase() {
		TreeNode root = generateTree();
		List<Integer> res = BinaryTree.inorderRecur(root);
		var actual = getInorderResult();
		assertIterableEquals(res, actual);
	}

	@Test
	void preorderIter_normalCase() {
		TreeNode root = generateTree();
		List<Integer> res = BinaryTree.preorderIter(root);
		var actual = getPreorderResult();
		assertIterableEquals(res, actual);
	}

	@Test
	void inorderIter_normalCase() {
		TreeNode root = generateTree();
		List<Integer> res = BinaryTree.inorderIter(root);
		var actual = getInorderResult();
		assertIterableEquals(res, actual);
	}

	@Test
	void postorderIter_normalCase() {
		TreeNode root = generateTree();
		List<Integer> res = BinaryTree.postorderIter(root);
		var actual = getPostorderResult();
		assertIterableEquals(res, actual);
	}

	@Test
	void bfs_normalCase() {
		TreeNode root = generateTree();
		List<Integer> res = BinaryTree.bfs(root);
		var actual = getBfResult();
		assertIterableEquals(res, actual);
	}

	private TreeNode generateTree() {
		TreeNode root = new TreeNode(1);
		root.setLeft(new TreeNode(2));
		root.setRight(new TreeNode(3));
		root.getLeft().setRight(new TreeNode(4));
		return root;
	}

	private List<Integer> getInorderResult() {
		var actual = new ArrayList<Integer>();
		actual.add(2);
		actual.add(4);
		actual.add(1);
		actual.add(3);
		return actual;
	}

	private List<Integer> getPreorderResult() {
		var actual = new ArrayList<Integer>();
		actual.add(1);
		actual.add(2);
		actual.add(4);
		actual.add(3);
		return actual;
	}

	private List<Integer> getPostorderResult() {
		var actual = new ArrayList<Integer>();
		actual.add(4);
		actual.add(2);
		actual.add(3);
		actual.add(1);
		return actual;
	}

	private List<Integer> getBfResult() {
		var actual = new ArrayList<Integer>();
		actual.add(1);
		actual.add(2);
		actual.add(3);
		actual.add(4);
		return actual;
	}
}
