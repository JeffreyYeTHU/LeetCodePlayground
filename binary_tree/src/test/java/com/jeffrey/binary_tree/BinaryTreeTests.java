package com.jeffrey.binary_tree;

import static org.junit.jupiter.api.Assertions.assertIterableEquals;

import java.util.ArrayList;
import java.util.List;

import org.junit.jupiter.api.Test;

class BinaryTreeTests {

	@Test
	void inorderTraversal_normalCase() {
		TreeNode root = generateTree();
		var res = BinaryTree.inorderTraversal(root);
		var actual = new ArrayList<Integer>();
		actual.add(2);
		actual.add(4);
		actual.add(3);
		actual.add(1);
		assertIterableEquals(res, actual);
	}

	TreeNode generateTree() {
		TreeNode root = new TreeNode(1);
		root.setLeft(new TreeNode(2));
		root.setRight(new TreeNode(3));
		root.getLeft().setRight(new TreeNode(4));
		return root;
	}
}
