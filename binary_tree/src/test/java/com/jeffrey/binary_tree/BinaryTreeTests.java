package com.jeffrey.binary_tree;

import static org.junit.jupiter.api.Assertions.assertIterableEquals;

import java.util.ArrayList;
import java.util.List;

import org.junit.jupiter.api.Test;

class BinaryTreeTests {

	@Test
	void inOrderRecur_normalCase() {
		TreeNode root = generateTree();
		List<Integer> res = BinaryTree.inOrderRecur(root);
		var actual = getInOrderResult();
		assertIterableEquals(res, actual);
	}

	@Test
	void preOrderIter_normalCase() {
		TreeNode root = generateTree();
		List<Integer> res = BinaryTree.preOrderIter(root);
		var actual = getPreOrderResult();
		assertIterableEquals(res, actual);
	}

	@Test
	void inOrderIter_normalCase() {
		TreeNode root = generateTree();
		List<Integer> res = BinaryTree.inOrderIter(root);
		var actual = getInOrderResult();
		assertIterableEquals(res, actual);
	}

	@Test
	void postOrderIter_normalCase() {
		TreeNode root = generateTree();
		List<Integer> res = BinaryTree.postOrderIter(root);
		var actual = getPostOrderResult();
		assertIterableEquals(res, actual);
	}

	@Test
	void bfs_normalCase() {
		TreeNode root = generateTree();
		List<Integer> res = BinaryTree.bfs(root);
		var actual = getBfsResult();
		assertIterableEquals(res, actual);
	}

	private TreeNode generateTree() {
		TreeNode root = new TreeNode(1);
		root.setLeft(new TreeNode(2));
		root.setRight(new TreeNode(3));
		root.getLeft().setRight(new TreeNode(4));
		return root;
	}

	private List<Integer> getInOrderResult() {
		var actual = new ArrayList<Integer>();
		actual.add(2);
		actual.add(4);
		actual.add(1);
		actual.add(3);
		return actual;
	}

	private List<Integer> getPreOrderResult() {
		var actual = new ArrayList<Integer>();
		actual.add(1);
		actual.add(2);
		actual.add(4);
		actual.add(3);
		return actual;
	}

	private List<Integer> getPostOrderResult() {
		var actual = new ArrayList<Integer>();
		actual.add(4);
		actual.add(2);
		actual.add(3);
		actual.add(1);
		return actual;
	}

	private List<Integer> getBfsResult() {
		var actual = new ArrayList<Integer>();
		actual.add(1);
		actual.add(2);
		actual.add(3);
		actual.add(4);
		return actual;
	}
}
